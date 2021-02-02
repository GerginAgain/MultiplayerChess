namespace Chess.Services
{
    using AutoMapper;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Chess.Services.Paging;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.InputModels.Videos;
    using Chess.Web.ViewModels.ViewModels.Videos;
    using Chess.Common;

    public class VideosService : IVideosService
    {
        private readonly ChessDbContext db;
        private readonly IPicturesService picturesService;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public VideosService(ChessDbContext db, IPicturesService picturesService, IMapper mapper, IUsersService usersService)
        {
            this.db = db;
            this.picturesService = picturesService;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task CreateVideoAsync(AddVideoInputModel model)
        {
            await this.picturesService.CreatePictureAsync(model.PictureName, model.PictureLink);
            var pictureFromDb = await this.picturesService.GetPictureByLinkAsync(model.PictureLink);

            var video = new Video
            {
                Title = model.VideoTitle,
                Link = model.VideoLink,
                Picture = pictureFromDb,
            };

            await this.db.Videos.AddAsync(video);
            await this.db.SaveChangesAsync();
        }

        public async Task<PaginatedList<VideoAllViewModel>> GetAllVideosViewModelsAsync(int pageNumber, int pageSize)
        {
            var currentUser = await this.usersService.GetCurrentUserAsync();

            if (currentUser != null)
            {
                var allVideos = this.db.Videos
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new VideoAllViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Link = x.Link,
                    IsInFavourites = x.UserFavouriteVideos.Any(y => y.VideoId == x.Id && y.ApplicationUserId == currentUser.Id)
                });

                var paginatedList = await PaginatedList<VideoAllViewModel>.CreateAsync(allVideos, pageNumber, pageSize);

                return paginatedList;
            }

            var allVideosFromDb = this.db.Videos
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn);

            var videoAllViewModels = mapper.ProjectTo<VideoAllViewModel>(allVideosFromDb);

            var paginatedListResult = await PaginatedList<VideoAllViewModel>.CreateAsync(videoAllViewModels, pageNumber, pageSize);

            return paginatedListResult;
        }

        public async Task<PaginatedList<ActiveVideoViewModel>> GetAllActiveVideosViewModelsAsync(int pageNumber, int pageSize)
        {
            var allVideosFromDb = this.db.Videos
               .Where(x => x.IsDeleted == false)
               .OrderByDescending(x => x.CreatedOn);

            var activeVideoViewModels = mapper.ProjectTo<ActiveVideoViewModel>(allVideosFromDb);

            var paginatedList = await PaginatedList<ActiveVideoViewModel>.CreateAsync(activeVideoViewModels, pageNumber, pageSize);

            return paginatedList;
        }

        public async Task<LatestThreeAddedVideosViewModel> GetLatestThreeVideosAsync()
        {
            var videos = this.db.Videos
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Take(3);

            var videosViewModel = await this.mapper.ProjectTo<VideoViewModel>(videos).ToArrayAsync();
            var currentUser = await this.usersService.GetCurrentUserAsync();

            if (currentUser != null)
            {
                for (int i = 0; i < videosViewModel.Length; i++)
                {
                    if (currentUser.UserFavouriteVideos.Any(x => x.VideoId == videosViewModel[i].Id))
                    {
                        videosViewModel[i].IsInFavourites = true;
                    }
                }
            }

            var latestThreeAddedVideosViewModel = new LatestThreeAddedVideosViewModel
            {
                Videos = videosViewModel,
            };

            return latestThreeAddedVideosViewModel;
        }

        public async Task<PaginatedList<FavouriteVideoViewModel>> GetFavouriteVideoViewModelsAsync(int pageNumber, int pageSize)
        {
            var user = await usersService.GetCurrentUserAsync();
            var favouritesVideosFromDb = this.db.Videos
                .Where(x => x.IsDeleted == false && x.UserFavouriteVideos.Any(y => y.ApplicationUserId == user.Id && y.VideoId == x.Id))
                .OrderByDescending(x => x.CreatedOn);

            var favoriteVideoViewModels = mapper.ProjectTo<FavouriteVideoViewModel>(favouritesVideosFromDb);
            var paginatedFavoriteVideos = await PaginatedList<FavouriteVideoViewModel>.CreateAsync(favoriteVideoViewModels, pageNumber, pageSize);

            return paginatedFavoriteVideos;
        }

        public async Task<int> GetCountOfAllVideosAsync()
        {
            var allVideosCount = await this.db.Videos.CountAsync();

            return allVideosCount;
        }

        public async Task<bool> DeleteVideoByIdAsync(int videoId)
        {
            if (!await this.db.Videos.AnyAsync(x => x.Id == videoId))
            {
                throw new ArgumentException(GlobalConstants.InvalidVideoIdErrorMessage);
            }

            var videoFromDb = await db.Videos.FirstOrDefaultAsync(x => x.Id == videoId);

            videoFromDb.IsDeleted = true;
            videoFromDb.DeletedOn = DateTime.UtcNow;
            db.Videos.Update(videoFromDb);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<PaginatedList<DeletedVideoViewModel>> GetAllDeletedVideosViewModelsAsync(int pageNumber, int pageSize)
        {
            var deletedVideosFromDb = this.db.Videos
                .Where(x => x.IsDeleted)
                .OrderByDescending(x => x.DeletedOn);

            var deletedVideoViewModels = mapper.ProjectTo<DeletedVideoViewModel>(deletedVideosFromDb);

            var paginatedList = await PaginatedList<DeletedVideoViewModel>.CreateAsync(deletedVideoViewModels, pageNumber, pageSize);

            return paginatedList;
        }

        public async Task<bool> RestoreVideoByIdAsync(int videoId)
        {
            if (!await this.db.Videos.AnyAsync(x => x.Id == videoId))
            {
                throw new ArgumentException(GlobalConstants.InvalidVideoIdErrorMessage);
            }

            var videoFromDb = await db.Videos.FirstOrDefaultAsync(x => x.Id == videoId);

            videoFromDb.IsDeleted = false;
            videoFromDb.DeletedOn = DateTime.UtcNow;
            db.Videos.Update(videoFromDb);
            await db.SaveChangesAsync();

            return true;
        }
    }
}
