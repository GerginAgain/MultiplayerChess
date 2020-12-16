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
