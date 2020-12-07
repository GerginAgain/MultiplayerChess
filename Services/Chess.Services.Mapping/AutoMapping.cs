using AutoMapper;
using Chess.Data.Models;
using Chess.Web.ViewModels.ViewModels.Games;
using Chess.Web.ViewModels.ViewModels.Users;
using System;
using System.Collections.Generic;
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
        }       
    }
}
