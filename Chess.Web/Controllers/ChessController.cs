using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Data;
using Chess.Data.Models;
using Chess.Web.Hubs;
using Chess.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Controllers
{
    public class ChessController : Controller
    {
        private ChessDbContext db;
        private readonly IHubContext<ChessHub> hubContext;

        public ChessController(ChessDbContext db, IHubContext<ChessHub> hubContext)
        {
            this.db = db;
            this.hubContext = hubContext;
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Games()
        {
            var games = this.db.Games.ToList();
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

            var game = new Game
            {
                Name = input.Name,
                Color = input.Color.ToString(),
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
            };

            return this.View("Game", gameViewModel);
        }

        public IActionResult EnterGame(int id)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);

            var color = string.Empty;
            if (game.Color == "White")
            {
                color = "Black";
            }
            else if (game.Color == "Black")
            {
                color = "White";
            }

            var gameViewModel = new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Color = color,
                HostConnectionId = game.HostConnectionId,
            };
            
            return this.View(gameViewModel);
        }
    }
}
