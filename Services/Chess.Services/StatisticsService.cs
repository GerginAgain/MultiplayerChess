using Chess.Services.Interfaces;
using Chess.Web.ViewModels.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chess.Data;
using Chess.Web.Infrastructure.CanvasJSModels;
using Chess.Common;

namespace Chess.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ChessDbContext context;
        private readonly IUsersService usersService;
        private readonly IGamesService gamesService;
        private readonly IVideosService videosService;

        public StatisticsService(ChessDbContext context, IUsersService usersService, IGamesService gamesService, IVideosService videosService)
        {
            this.context = context;
            this.usersService = usersService;
            this.gamesService = gamesService;
            this.videosService = videosService;
        }

        public async Task<AdministrationIndexStatisticViewModel> GetAdministrationIndexStatisticViewModel()
        {
            var allUsersCount = await usersService.GetCountOfAllUsersAsync();
            var allGamesCount = await gamesService.GetCountOfAllGamesAsync();
            var allVideosCount = await videosService.GetCountOfAllGamesAsync();

            var administrationIndexStatisticViewModel = new AdministrationIndexStatisticViewModel
            {
                AllUsersCount = allUsersCount,
                AllGamesCount = allGamesCount,
                AllVideosCount = allVideosCount,
            };

            return administrationIndexStatisticViewModel;
        }

        public async Task<IEnumerable<DataPoint>> GetDataPointsForCreatedGamesAsync()
        {
            var lastTenDates = this.GetLastTenDaysAsString();
            var countOfCreatedGames = await gamesService.GetTheCountForTheCreatedGamesForTheLastTenDaysAsync();

            var dataPoints = new List<DataPoint>();

            for (int i = 0; i < GlobalConstants.CreatedGamesStatisticDaysCount; i++)
            {
                var dataPoint = new DataPoint(countOfCreatedGames[i], lastTenDates[i]);
                dataPoints.Add(dataPoint);
            }

            return dataPoints;
        }

        private List<string> GetLastTenDaysAsString()
        {
            var dates = new List<string>();

            for (DateTime dt = DateTime.UtcNow.AddDays(-GlobalConstants.CreatedGamesStatisticDaysCount + 1); dt <= DateTime.UtcNow; dt = dt.AddDays(1))
            {
                dates.Add(dt.ToString("dd MMM"));
            }

            return dates;
        }
    }
}
