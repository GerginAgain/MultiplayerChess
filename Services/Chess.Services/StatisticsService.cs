namespace Chess.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Chess.Web.Infrastructure.CanvasJSModels;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Statistics;
    using Chess.Common;

    public class StatisticsService : IStatisticsService
    {
        private readonly IUsersService usersService;
        private readonly IGamesService gamesService;
        private readonly IVideosService videosService;

        public StatisticsService(IUsersService usersService, IGamesService gamesService, IVideosService videosService)
        {
            this.usersService = usersService;
            this.gamesService = gamesService;
            this.videosService = videosService;
        }

        public async Task<AdministrationIndexStatisticViewModel> GetAdministrationIndexStatisticViewModelAsync()
        {
            var allUsersCount = await usersService.GetCountOfAllUsersAsync();
            var allGamesCount = await gamesService.GetCountOfAllGamesAsync();
            var allVideosCount = await videosService.GetCountOfAllVideosAsync();

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
