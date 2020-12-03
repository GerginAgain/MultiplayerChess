using AutoMapper;
using Chess.Data.Models;
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
        }       
    }
}
