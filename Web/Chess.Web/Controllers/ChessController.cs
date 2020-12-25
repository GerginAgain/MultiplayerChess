namespace Chess.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Chess.Web.Hubs;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.InputModels.Games;

    public class ChessController : Controller
    {
        private readonly IHubContext<ChessHub> hubContext;
        private readonly IGamesService gamesService;

        public ChessController(IHubContext<ChessHub> hubContext, IGamesService gamesService)
        {
            this.hubContext = hubContext;
            this.gamesService = gamesService;
        }

        public async Task<IActionResult> Games()
        {
            var viewModel = await this.gamesService.GetGamesViewModelAsync();

            return View(viewModel);
        }

        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(GameInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var gameViewModel = await this.gamesService.GetGameViewModelAsync(input);
            await this.hubContext.Clients.All.SendAsync("AddNewGame", gameViewModel.Name, gameViewModel.Color, gameViewModel.Id);

            return this.View("Game", gameViewModel);
        }

        public async Task<IActionResult> EnterGame(string id)
        {
            var gameViewModel = await this.gamesService.GetEnteringGameViewModelAsync(id);
            await this.hubContext.Clients.Client(gameViewModel.HostConnectionId).SendAsync("AddGuestToDashboard", gameViewModel.GuestName);

            return this.View(gameViewModel);
        }

        public IActionResult DeletedGame()
        {
            return this.View();
        }
    }
}
