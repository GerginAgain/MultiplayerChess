using Chess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Chess.Data.Models;
using Chess.Data;
using Chess.Web.ViewModels.ViewModels.Users;
using Chess.Services.Paging;
using System.Linq;
using AutoMapper;
using Chess.Services.Mapping;

namespace Chess.Services
{
    public class UsersService : IUsersService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly ChessDbContext context;

        public UsersService(ChessDbContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.contextAccessor = contextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<int> GetCountOfAllUsersAsync()
        {
            var allUsersCount = await context.Users.CountAsync(x => !x.IsDeleted);

            return allUsersCount;
        }
        public async Task<PaginatedList<UserAllViewModel>> GetAllUserViewModelsAsync(int pageNumber, int pageSize)
        {
            var allUsers = context.ApplicationUsers
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn);
            //.ToArray();
            //.To<UserAllViewModel>();

            //var ienumerableDest = mapper.Map<ApplicationUser[], IEnumerable<UserAllViewModel>>(userAllViewModels).AsQueryable();
            var UserAllViewModels = mapper.ProjectTo<UserAllViewModel>(allUsers);
            //return await _mapper.ProjectTo<SomeViewModel>(dbContext.SomeEntity).ToListAsync();

            var paginatedList = await PaginatedList<UserAllViewModel>.CreateAsync(UserAllViewModels, pageNumber, pageSize);

            return paginatedList;
        }
    }
}
