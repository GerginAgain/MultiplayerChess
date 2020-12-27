namespace Chess.Services
{      
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Common;
    using Chess.Services.Paging;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.InputModels.Games;
    using Chess.Web.ViewModels.ViewModels.Games;

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

        public async Task AddHostConnectionIdToGameAsync(string gameId, string hostConnectionId)
        {
            var currentGame = await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            currentGame.HostConnectionId = hostConnectionId;
            await this.db.SaveChangesAsync();
        }

        public async Task AddGuestConnectionIdToGameAsync(string gameId, string guestConnectionId)
        {
            var currentGame = await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            currentGame.GuestConnectionId = guestConnectionId;
            await this.db.SaveChangesAsync();
        }

        public async Task<HubGameViewModel> GetHubGameViewModelByGameIdAsync(string gameId)
        {
            var currentGame = await this.db.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            var hubGameViewModel = mapper.Map<HubGameViewModel>(currentGame);

            return hubGameViewModel;
        }

        public async Task<PaginatedList<MyGameViewModel>> GetMyGameViewModelsAsync(int pageNumber, int pageSize)
        {
            var currentUserId = this.userManager.GetUserId(this.httpContext.HttpContext.User);

            var allMyGames = db.Games
                .Where(x => x.HostId == currentUserId || x.GuestId == currentUserId)
                .Where(x => !x.IsActive)
                .OrderByDescending(x => x.CreatedOn);

            var myGameViewModels = mapper.ProjectTo<MyGameViewModel>(allMyGames);
            var paginatedList = await PaginatedList<MyGameViewModel>.CreateAsync(myGameViewModels, pageNumber, pageSize);
            return paginatedList;
        }

        public async Task<Game> GetGameByConnectionIdAndIsActiveStatusAsync(string connectionId)
        {
            var abandonedGame = await this.db.Games
                .FirstOrDefaultAsync(x => x.HostConnectionId == connectionId && x.IsActive == true);

            return abandonedGame;
        }

        public async Task MakeGameInActiveAsync(string gameId)
        {
            var game = await this.GetGameByIdAsync(gameId);
            game.IsActive = false;
            await this.db.SaveChangesAsync();
        }

        public async Task<Game> GetFinishedGameByConnectionIdAsync(string connectionId)
        {
            var finishedGame = await this.db.Games
                .FirstOrDefaultAsync(x => (x.HostConnectionId == connectionId || x.GuestConnectionId == connectionId)
                                            && x.IsActive == false);

            return finishedGame;
        }
    }
}
