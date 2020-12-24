using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chess.Common;
using Chess.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Chess.Web.Hubs;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IGamesService gamesService;
        private readonly IHubContext<ChessHub> hubContext;

        public UsersController(IUsersService usersService, IGamesService gamesService, IHubContext<ChessHub> hubContext)
        {
            this.usersService = usersService;
            this.gamesService = gamesService;
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> Active(int? pageNumber)
        {
            var allUserViewModels = await usersService.GetAllUserViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultPageSize);

            return View(allUserViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Block(string userId)
        {
            var isBlocked = await usersService.BlockUserByIdAsync(userId);
            var gameId = await gamesService.GetActiveGameIdByUserIdAsync(userId);

            if (gameId != null)
            {
                await gamesService.DeleteGameByIdAsync(gameId);
                await this.hubContext.Clients.All.SendAsync("DeleteGame", gameId);
            }

            return Json(isBlocked);
        }

        public async Task<IActionResult> Blocked(int? pageNumber)
        {
            var allBlockedUserViewModels = await this.usersService.GetAllBlockedUserViewModels(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultPageSize);

            return this.View(allBlockedUserViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Unblock(string userId)
        {
            var isUnblocked = await this.usersService.UnblockUserByIdAsync(userId);

            return Json(isUnblocked);
        }
    }
}
