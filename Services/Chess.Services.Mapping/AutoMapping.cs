using AutoMapper;
using Chess.Data.Models;
using Chess.Web.ViewModels.ViewModels.Games;
using Chess.Web.ViewModels.ViewModels.Users;
using Chess.Web.ViewModels.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Services.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUser, UserAllViewModel>();
            CreateMap<ApplicationUser, BlockedUserAllViewModel>();
            CreateMap<Game, ActiveGameAllViewModel>()
                .ForMember(x => x.Title, cfg => cfg.MapFrom(x => x.Name));
            CreateMap<Game, GameDetailsViewModel>()
                .ForMember(x => x.HostFiguresColor, cfg => cfg.MapFrom(x => x.Color))
                .ForMember(x => x.HostUsername, cfg => cfg.MapFrom(x => x.Host.UserName));
            CreateMap<Video, VideoViewModel>()
                .ForMember(x => x.Id, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(x => x.PictureName, cfg => cfg.MapFrom(x => x.Picture.Name))
                .ForMember(x => x.PictureLink, cfg => cfg.MapFrom(x => x.Picture.Link));
            CreateMap<Video, VideoAllViewModel>();
            CreateMap<Video, FavouriteVideoViewModel>();
            //CreateMap<VideoAllViewModel, VideoAllWithFavouritesViewModel>();
            //.ForMember(x => x.IsInFavourites, cfg => cfg.MapFrom(x => x.UserFavouriteVideos.Any(y => y.VideoId == x.Id)));
        }       
    }
}
