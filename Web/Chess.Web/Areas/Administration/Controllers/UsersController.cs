using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chess.Common;
using Chess.Services.Interfaces;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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

            return Json(isBlocked);
        }

        public async Task<IActionResult> Blocked(int? pageNumber)
        {
            var allBlockedUserViewModels = await this.usersService.GetAllBlockedUserViewModels(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultPageSize);

            return this.View(allBlockedUserViewModels);
        }
    }
}
