using Chess.Data;
using Chess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chess.Services.Paging;
using Chess.Web.ViewModels.ViewModels.Games;
using AutoMapper;
using System.Linq;
using Chess.Common;
using Chess.Data.Models;
using Chess.Web.ViewModels.InputModels.Games;
using Microsoft.AspNetCore.Http;


using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Chess.Services
{
    public class GamesService : IGamesService
    {
        private readonly ChessDbContext db;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<ApplicationUser> userManager;

        public GamesService(ChessDbContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
        {
            this.db = context;
            this.mapper = mapper;
            this.httpContext = httpContext;
            this.userManager = userManager;
        }

        public async Task<PaginatedList<ActiveGameAllViewModel>> GetAllActiveGamesViewModelsAsync(int pageNumber, int pageSize)
        {
            var allGames = db.Games
               .Where(x => x.IsActive)
               .OrderByDescending(x => x.CreatedOn);

            var gameAllViewModels = mapper.ProjectTo<ActiveGameAllViewModel>(allGames);
            var paginatedList = await PaginatedList<ActiveGameAllViewModel>.CreateAsync(gameAllViewModels, pageNumber, pageSize);
            return paginatedList;
        }

        public async Task<int> GetCountOfAllGamesAsync()
        {
            var allGamesCount = await db.Games.Where(x => x.IsActive).CountAsync();

            return allGamesCount;
        }

        public async Task<Game> GetGameByIdAsync(string gameId)
        {
            return await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
        }

        public async Task<GameDetailsViewModel> GetGameDetailsViewModelAsync(string gameId)
        {
            if (!await db.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            var gameDetailsViewModel = mapper.Map<GameDetailsViewModel>(gameFromDb);
            return gameDetailsViewModel;
        }

        public async Task DeleteGameByIdAsync(string gameId)
        {
            if (!await db.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            gameFromDb.IsActive = false;
            await this.db.SaveChangesAsync();          
        }

        public async Task<string> GetActiveGameIdByUserIdAsync(string userId)
        {
            var game = await this.db.Games
                .FirstOrDefaultAsync(x => x.IsActive == true && x.HostId == userId);

            string gameId = null;

            if (game != null)
            {
                gameId = game.Id;
            }

            return gameId;
        }

        public async Task<List<int>> GetTheCountForTheCreatedGamesForTheLastTenDaysAsync()
        {
            var gamesCount = new List<int>();

            for (DateTime i = DateTime.UtcNow.AddDays(-GlobalConstants.CreatedGamesStatisticDaysCount + 1);
                i <= DateTime.UtcNow;
                i = i.AddDays(1))
            {
                var currentDaysGamesCount = await db.Games
                    .CountAsync(x => x.CreatedOn.DayOfYear == i.DayOfYear);

                gamesCount.Add(currentDaysGamesCount);
            }

            return gamesCount;
        }

        public Task<string> GetOpponentUserConnectionIdAsync(string currentUserConnectionId, string gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GameAllViewModel>> GetGameAllViewModelsAsync()
        {
            var games = this.db.Games.Where(x => x.IsActive == true);

            var gameAllViewModels = await mapper.ProjectTo<GameAllViewModel>(games).ToListAsync();
            return gameAllViewModels;
        }

        public async Task<GamesViewModel> GetGamesViewModelAsync()
        {
            var gameAllViewModels = await this.GetGameAllViewModelsAsync();

            var gamesViewModel = new GamesViewModel
            {
                Games = gameAllViewModels,
            };

            return gamesViewModel;
        }

        public async Task<GameViewModel> GetGameViewModelAsync(GameInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.httpContext.HttpContext.User);

            var game = new Game
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name,
                Color = input.Color.ToString(),
                HostId = userId,
            };

            await this.db.Games.AddAsync(game);
            await this.db.SaveChangesAsync();

            var gameViewModel = mapper.Map<GameViewModel>(game);
            return gameViewModel;
        }

        public async Task<GameViewModel> GetEnteringGameViewModelAsync(string id)
        {
            var game = await this.db.Games.FirstOrDefaultAsync(x => x.Id == id);
            var guestId = this.userManager.GetUserId(this.httpContext.HttpContext.User);
            game.IsActive = false;
            game.GuestId = guestId;
            await db.SaveChangesAsync();

            var color = string.Empty;
            if (game.Color == "White")
            {
                color = "Black";
            }
            else if (game.Color == "Black")
            {
                color = "White";
            }

            //var hostName = game.Host.UserName; //this.db.ApplicationUsers.FirstOrDefault(x => x.Id == game.HostId).UserName;

            var gameViewModel = new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Color = color,
                HostConnectionId = game.HostConnectionId,
                HostName = game.Host.UserName,
                GuestName = this.httpContext.HttpContext.User.Identity.Name,
            };

            return gameViewModel;
        }
    }
}
