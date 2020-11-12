using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Data;
using Chess.Data.Models;
using Chess.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    public class ChessController : Controller
    {
        private ChessDbContext db;

        public ChessController(ChessDbContext db)
        {
            this.db = db;
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
        public IActionResult CreateGame(GameInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var game = new Game
            {
                Name = input.Name,
                Color = input.Color.ToString(),
                //HostConnectionId = input.HostConnectionId
            };

            this.db.Games.Add(game);
            this.db.SaveChanges();

            var currentGameWithId = this.db.Games
                .First(x => x.Name == game.Name);

            var gameViewModel = new GameViewModel
            {
                Id = currentGameWithId.Id,
                Name = currentGameWithId.Name,
                Color = currentGameWithId.Color,             
            };

            ViewData["Color"] = game.Color;
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
