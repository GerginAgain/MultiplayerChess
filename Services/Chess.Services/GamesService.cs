using Chess.Data;
using Chess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
            //.ToArray();
            //.To<UserAllViewModel>();

            //var ienumerableDest = mapper.Map<ApplicationUser[], IEnumerable<UserAllViewModel>>(userAllViewModels).AsQueryable();
            var GameAllViewModels = mapper.ProjectTo<ActiveGameAllViewModel>(allGames);
            //return await _mapper.ProjectTo<SomeViewModel>(dbContext.SomeEntity).ToListAsync();

            var paginatedList = await PaginatedList<ActiveGameAllViewModel>.CreateAsync(GameAllViewModels, pageNumber, pageSize);

            return paginatedList;
        }

        public async Task<int> GetCountOfAllGamesAsync()
        {
            var allGamesCount = await context.Games.Where(x => x.IsActive).CountAsync();

            return allGamesCount;
        }

        public async Task<Game> GetGameByIdAsync(int gameId)
        {
            return await this.context.Games.FirstOrDefaultAsync(x => x.Id == gameId);
        }

        public async Task<GameDetailsViewModel> GetGameDetailsViewModelAsync(int gameId)
        {
            if (!await context.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            var gameDetailsViewModel = mapper.Map<GameDetailsViewModel>(gameFromDb);
            return gameDetailsViewModel;
        }

        public async Task DeleteGameByIdAsync(int gameId)
        {
            if (!await context.Games.AnyAsync(x => x.Id == gameId))
            {
                throw new ArgumentException(GlobalConstants.InvalidGameIdErrorMessage);
            }

            var gameFromDb = await GetGameByIdAsync(gameId);
            gameFromDb.IsActive = false;
            await this.context.SaveChangesAsync();          
        }

        public async Task<int> GetActiveGameIdByUserIdAsync(string userId)
        {
            var game = await this.context.Games
                .FirstOrDefaultAsync(x => x.IsActive == true && x.HostId == userId);

            var gameId = game.Id;

            return gameId;
        }
    }
}
