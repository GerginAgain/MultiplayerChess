namespace Chess.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Chess.Web.Infrastructure.CanvasJSModels;
    using Chess.Web.ViewModels.ViewModels.Statistics;

    public interface IStatisticsService
    {
        Task<AdministrationIndexStatisticViewModel> GetAdministrationIndexStatisticViewModelAsync();

        Task<IEnumerable<DataPoint>> GetDataPointsForCreatedGamesAsync();
    }
}
