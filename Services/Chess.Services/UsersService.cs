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

namespace Chess.Services
{
    public class UsersService : IUsersService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ChessDbContext context;

        public UsersService(ChessDbContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.contextAccessor = contextAccessor;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<int> GetCountOfAllUsersAsync()
        {
            var allUsersCount = await context.Users.CountAsync(x => !x.IsDeleted);

            return allUsersCount;
        }
    }
}
