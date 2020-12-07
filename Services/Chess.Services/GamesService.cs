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
    }
}
