﻿namespace Chess.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;   
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Chess.Common;
    using Chess.Services.Interfaces;
    using Chess.Web.Hubs;
    using Chess.Web.ViewModels.InputModels.Games;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly IHubContext<ChessHub> hubContext;
        private readonly IUsersService usersService;

        public GamesController(IGamesService gamesService, IHubContext<ChessHub> hubContext, IUsersService usersService)
        {
            this.gamesService = gamesService;
            this.hubContext = hubContext;
            this.usersService = usersService;
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
        public async Task<IActionResult> Delete(string gameId)
        {
            await gamesService.DeleteGameByIdAsync(gameId);
            await this.hubContext.Clients.All.SendAsync("DeleteGame", gameId);
            var hostConnectionId = await this.usersService.GetUserHostConnectionIdByGameIdAsync(gameId);
            await this.hubContext.Clients.Client(hostConnectionId).SendAsync("RedirectToDeletedGame");

            return Json(true);
        }
    }
}
