using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chess.Common;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : Controller
    {
        //public async Task<IActionResult> Active(int? pageNumber)
        //{
        //    var allUserViewModels = await usersService.GetAllUserViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultPageSize);

        //    return View(allUserViewModels);
        //}
    }
}
