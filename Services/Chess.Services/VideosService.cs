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

namespace Chess.Services
{
    public class VideosService : IVideosService
    {
        private readonly ChessDbContext db;
        private readonly IPicturesService picturesService;
        private readonly IMapper mapper;

        public VideosService(ChessDbContext db, IPicturesService picturesService, IMapper mapper)
        {
            this.db = db;
            this.picturesService = picturesService;
            this.mapper = mapper;
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

            var latestThreeAddedVideosViewModel = new LatestThreeAddedVideosViewModel
            {
                Videos = videosViewModel,
            };

            return latestThreeAddedVideosViewModel;
        }
    }
}
