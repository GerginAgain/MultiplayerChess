using Chess.Services.Interfaces;
using Chess.Web.ViewModels.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chess.Data;

namespace Chess.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ChessDbContext context;
        private readonly IUsersService usersService;
        private readonly IGamesService gamesService;

        public StatisticsService(ChessDbContext context, IUsersService usersService, IGamesService gamesService)
        {
            this.context = context;
            this.usersService = usersService;
            this.gamesService = gamesService;
        }

        public async Task<AdministrationIndexStatisticViewModel> GetAdministrationIndexStatisticViewModel()
        {
            var allUsersCount = await usersService.GetCountOfAllUsersAsync();
            var allGamesCount = await gamesService.GetCountOfAllGamesAsync();

            var administrationIndexStatisticViewModel = new AdministrationIndexStatisticViewModel
            {
                AllUsersCount = allUsersCount,
                AllGamesCount = allGamesCount
            };

            return administrationIndexStatisticViewModel;
        }
    }
}
