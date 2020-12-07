using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Common;
using Chess.Services;
using Chess.Services.Interfaces;
using Chess.Web.Hubs;
using Chess.Web.ViewModels.InputModels.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly IHubContext<ChessHub> hubContext;

        public GamesController(IGamesService gamesService, IHubContext<ChessHub> hubContext)
        {
            this.gamesService = gamesService;
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> AllActiveGames(int? pageNumber)
        {
            var allActiveGameViewModel = await gamesService.GetAllActiveGamesViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultPageSize);

            return View(allActiveGameViewModel);
        }

        public async Task<IActionResult> Details(GameDetailsInputModel inputModel)
        {
            var gameDetailsViewModel = await gamesService.GetGameDetailsViewModelAsync(inputModel.Id);

            return View(gameDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int gameId)
        {
            await gamesService.DeleteGameByIdAsync(gameId);
            await this.hubContext.Clients.All.SendAsync("DeleteGame", gameId);

            return Json(true);
        }
    }
}
