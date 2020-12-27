namespace Chess.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        public IActionResult Blocked()
        {
            return View();
        }
    }
}
