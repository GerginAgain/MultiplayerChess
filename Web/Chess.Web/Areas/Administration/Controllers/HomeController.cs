namespace Chess.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Chess.Common;
    using Chess.Services.Interfaces;

    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class HomeController : Controller
    {
        private readonly IStatisticsService statisticsService;

        private readonly JsonSerializerSettings jsonSetting;

        public HomeController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
            jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        public async Task<IActionResult> Index()
        {
            var administrationIndexStatisticViewModel = await statisticsService.GetAdministrationIndexStatisticViewModelAsync();
            var gamesByDaysStatisticPoints = await this.statisticsService.GetDataPointsForCreatedGamesAsync();

            ViewBag.DataPointsGames = JsonConvert.SerializeObject(gamesByDaysStatisticPoints, jsonSetting);

            return View(administrationIndexStatisticViewModel);
        }
    }
}
