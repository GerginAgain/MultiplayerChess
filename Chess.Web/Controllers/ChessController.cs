using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    public class ChessController : Controller
    {
        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }
    }
}
