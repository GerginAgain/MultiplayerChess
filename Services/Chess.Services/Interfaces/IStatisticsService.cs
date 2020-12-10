using Chess.Web.Infrastructure.CanvasJSModels;
using Chess.Web.ViewModels.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<AdministrationIndexStatisticViewModel> GetAdministrationIndexStatisticViewModel();

        Task<IEnumerable<DataPoint>> GetDataPointsForCreatedGamesAsync();
    }
}
