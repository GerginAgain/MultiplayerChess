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

namespace Chess.Services
{
    public class GamesService : IGamesService
    {
        private readonly ChessDbContext context;
        private readonly IMapper mapper;

        public GamesService(ChessDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<ActiveGameAllViewModel>> GetAllActiveGamesViewModelsAsync(int pageNumber, int pageSize)
        {
            var allGames = context.Games
               .Where(x => x.IsActive)
               .OrderByDescending(x => x.CreatedOn);

            var gameAllViewModels = mapper.ProjectTo<ActiveGameAllViewModel>(allGames);
            var paginatedList = await PaginatedList<ActiveGameAllViewModel>.CreateAsync(gameAllViewModels, pageNumber, pageSize);
            return paginatedList;
        }

        public async Task<int> GetCountOfAllGamesAsync()
        {
            var allGamesCount = await context.Games.Where(x => x.IsActive).CountAsync();

            return allGamesCount;
        }

        public async Task<Game> GetGameByIdAsync(string gameId)
        {
            return await this.context.Games.FirstOrDefaultAsync(x => x.Id == gameId);
        }

        public async Task<GameDetailsViewModel> GetGameDetailsViewModelAsync(string gameId)
        {
            if (!await context.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            var gameDetailsViewModel = mapper.Map<GameDetailsViewModel>(gameFromDb);
            return gameDetailsViewModel;
        }

        public async Task DeleteGameByIdAsync(string gameId)
        {
            if (!await context.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            gameFromDb.IsActive = false;
            await this.context.SaveChangesAsync();          
        }

        public async Task<string> GetActiveGameIdByUserIdAsync(string userId)
        {
            var game = await this.context.Games
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
                var currentDaysGamesCount = await context.Games
                    .CountAsync(x => x.CreatedOn.DayOfYear == i.DayOfYear);

                gamesCount.Add(currentDaysGamesCount);
            }

            return gamesCount;
        }

        public Task<string> GetOpponentUserConnectionIdAsync(string currentUserConnectionId, string gameId)
        {
            throw new NotImplementedException();
        }
    }
}
