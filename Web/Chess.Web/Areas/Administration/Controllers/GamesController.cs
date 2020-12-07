using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Common;
using Chess.Services;
using Chess.Services.Interfaces;
using Chess.Web.ViewModels.InputModels.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
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
    }
}
