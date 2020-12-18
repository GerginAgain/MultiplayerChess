using AutoMapper;
using Chess.Data;
using Chess.Data.Models;
using Chess.Services.Interfaces;
using Chess.Web.ViewModels.InputModels.Videos;
using Chess.Web.ViewModels.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Chess.Services.Paging;
using AutoMapper.QueryableExtensions;

namespace Chess.Services
{
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

        public async Task<LatestThreeAddedVideosViewModel> GetLatestThreeVideosAsync()
        {
            var videos = this.db.Videos
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
    }
}
