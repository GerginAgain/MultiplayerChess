using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Data;
using Chess.Data.Models;
using Chess.Web.Hubs;
using Chess.Web.ViewModels.ViewModels;
using Chess.Web.ViewModels.InputModels.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;

namespace Chess.Web.Controllers
{
    public class ChessController : Controller
    {
        private ChessDbContext db;
        private readonly IHubContext<ChessHub> hubContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ChessController(ChessDbContext db, IHubContext<ChessHub> hubContext, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.hubContext = hubContext;
            this.userManager = userManager;
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Games()
        {
            var games = this.db.Games.Where(x => x.IsActive == true).ToList();
            var viewModel = new GamesViewModel
            {
                Games = games,
            };

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

            var hostId = this.userManager.GetUserId(this.User);

            var game = new Game
            {
                Name = input.Name,
                Color = input.Color.ToString(),
                HostId = hostId,
            };

            this.db.Games.Add(game);
            await this.db.SaveChangesAsync();

            var currentGameWithId = this.db.Games
                .First(x => x.Name == game.Name);

            var name = currentGameWithId.Name;
            var color = currentGameWithId.Color;
            var gameId = currentGameWithId.Id;

            await this.hubContext.Clients.All.SendAsync("AddNewGame", name, color, gameId);

            var gameViewModel = new GameViewModel
            {
                Id = currentGameWithId.Id,
                Name = currentGameWithId.Name,
                Color = currentGameWithId.Color, 
                HostName = this.HttpContext.User.Identity.Name,
            };

            return this.View("Game", gameViewModel);
        }

        public async Task<IActionResult> EnterGame(int id)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);
            game.IsActive = false;
            var guestId = this.userManager.GetUserId(this.User);
            game.GuestId = guestId;
            db.SaveChanges();

            var color = string.Empty;
            if (game.Color == "White")
            {
                color = "Black";
            }
            else if (game.Color == "Black")
            {
                color = "White";
            }

            var hostName = this.db.ApplicationUsers.FirstOrDefault(x => x.Id == game.HostId).UserName;

            var gameViewModel = new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Color = color,
                HostConnectionId = game.HostConnectionId,
                HostName = hostName,
                GuestName = this.HttpContext.User.Identity.Name,
            };

            var guestName = this.HttpContext.User.Identity.Name;
            await this.hubContext.Clients.Client(game.HostConnectionId).SendAsync("AddGuestToDashboard", guestName);

            return this.View(gameViewModel);
        }

        public IActionResult DeletedGame()
        {
            return this.View();
        }
    }
}
