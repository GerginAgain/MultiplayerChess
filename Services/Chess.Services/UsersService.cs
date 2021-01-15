namespace Chess.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Chess.Services.Paging;
    using System.Linq;
    using AutoMapper;
    using Chess.Common;
    using Chess.Data.Models;
    using Chess.Data;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IGamesService gamesService;
        private readonly ChessDbContext context;

        public UsersService(ChessDbContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, IGamesService gamesService)
        {
            this.contextAccessor = contextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
            this.gamesService = gamesService;
            this.context = context;
        }

        public async Task<int> GetCountOfAllUsersAsync()
        {
            var allUsersCount = await context.Users.CountAsync(x => /*!x.IsDeleted &&*/ x.UserName != "admin");

            return allUsersCount;
        }

        public async Task<PaginatedList<UserAllViewModel>> GetAllUserViewModelsAsync(int pageNumber, int pageSize)
        {
            var allUsers = context.ApplicationUsers
                .Where(x => !x.IsDeleted && x.UserName != "admin")
                .OrderByDescending(x => x.CreatedOn);

            var UserAllViewModels = mapper.ProjectTo<UserAllViewModel>(allUsers);
            var paginatedList = await PaginatedList<UserAllViewModel>.CreateAsync(UserAllViewModels, pageNumber, pageSize);
            
            return paginatedList;
        }

        public async Task<bool> BlockUserByIdAsync(string userId)
        {
            if (!await this.context.ApplicationUsers.AnyAsync(x => x.Id == userId))
            {
                throw new ArgumentException(GlobalConstants.InvalidUserIdErrorMessage);
            }

            var userFromDb = await context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == userId);

            userFromDb.IsDeleted = true;
            userFromDb.DeletedOn = DateTime.UtcNow;
            context.ApplicationUsers.Update(userFromDb);
            await context.SaveChangesAsync();

            await this.userManager.UpdateSecurityStampAsync(userFromDb);

            return true;
        }

        public async Task<PaginatedList<BlockedUserAllViewModel>> GetAllBlockedUserViewModelsAsync(int pageNumber, int pageSize)
        {
            var blockedUsers = this.context
                .ApplicationUsers
                .Where(x => x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn);

            var BlockedUserAllViewModels = mapper.ProjectTo<BlockedUserAllViewModel>(blockedUsers);
            var paginatedList = await PaginatedList<BlockedUserAllViewModel>.CreateAsync(BlockedUserAllViewModels, pageNumber, pageSize);

            return paginatedList;
        }

        public async Task<bool> UnblockUserByIdAsync(string userId)
        {
            if (!await this.context.ApplicationUsers.AnyAsync(x => x.Id == userId))
            {
                throw new ArgumentException(GlobalConstants.InvalidUserIdErrorMessage);
            }

            var userFromDb = await context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == userId);

            userFromDb.IsDeleted = false;

            context.ApplicationUsers.Update(userFromDb);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            var userFromDb = await this.context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            return userFromDb;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var currentUser = await userManager.GetUserAsync(contextAccessor.HttpContext.User);
            
            return currentUser;
        }

        public async Task<string> GetUserHostConnectionIdByGameIdAsync(string gameId)
        {
            var game = await this.gamesService.GetGameByIdAsync(gameId);
            var hostConnectionId = game.HostConnectionId;
            return hostConnectionId;
        }
    }
}
