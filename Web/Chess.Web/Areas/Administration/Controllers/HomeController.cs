using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Common;
using Chess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Chess.Web.Areas.Administration.Controllers
{
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
            var administrationIndexStatisticViewModel = await statisticsService.GetAdministrationIndexStatisticViewModel();

            var gamesByDaysStatisticPoints = await this.statisticsService.GetDataPointsForCreatedGamesAsync();
            //var promotionsByDaysStatisticPoints = await this.statisticsService.GetPointsForPromotionsAsync();

            ViewBag.DataPointsGames = JsonConvert.SerializeObject(gamesByDaysStatisticPoints, jsonSetting);
            //ViewBag.DataPointsPromotions = JsonConvert.SerializeObject(promotionsByDaysStatisticPoints, jsonSetting);

            return View(administrationIndexStatisticViewModel);
        }
    }
}
