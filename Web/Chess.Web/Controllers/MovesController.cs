namespace Chess.Web.Controllers
{
    using Chess.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MovesController : Controller
    {
        private readonly IMovesService movesService;

        public MovesController(IMovesService movesService)
        {
            this.movesService = movesService;
        }

        public async Task<IActionResult> MyGameAllMoves(string id)
        {
            var moveViewModels = await  this.movesService.GetGameAllMovesViewModelByGameIdAsync(id);
            return View(moveViewModels);
        }
    }
}
