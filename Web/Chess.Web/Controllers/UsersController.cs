using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Blocked()
        {
            return View();
        }
    }
}
