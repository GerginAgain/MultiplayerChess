﻿namespace Chess.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    using Chess.Common;
    using Chess.Data;
    using Chess.Services.Interfaces;
    using System;
    using Chess.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    public class ChessHub : Hub
    {
        private readonly ChessDbContext db;
        private readonly IGamesService gamesService;
        private readonly IMovesService movesService;
        private readonly IMessagesService messagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ChessHub(ChessDbContext db, IGamesService gamesService, IMovesService movesService, IMessagesService messagesService, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.gamesService = gamesService;
            this.movesService = movesService;
            this.messagesService = messagesService;
            this.userManager = userManager;
        }

        public async Task SendNewMessage(string message, string gameId)
        {
            await this.messagesService.AddMessageToDbAsync(message, gameId);

            var currentUserConnectionId = this.Context.ConnectionId;
            var currentGame = await this.gamesService.GetHubGameViewModelByGameIdAsync(gameId);
            var opponentUserId = string.Empty;

            if (currentGame.HostConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.GuestConnectionId;
            }
            else if (currentGame.GuestConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.HostConnectionId;
            }

            string userName = this.Context.User.Identity.Name;
            await this.Clients.Client(opponentUserId).SendAsync("ReceiveNewMessage", userName, message);
        }

        public async Task SendNewMoveToBoard(string startId, string targetId, string gameId) 
        {
            var currentUserConnectionId = this.Context.ConnectionId;
            var currentGame = await this.gamesService.GetHubGameViewModelByGameIdAsync(gameId);
            var opponentUserId = string.Empty;

            if (currentGame.HostConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.GuestConnectionId;
            }
            else if (currentGame.GuestConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.HostConnectionId;
            }

            await Clients.Client(opponentUserId).SendAsync("ReceiveNewMove", startId, targetId);       
        }

        public async Task SendNewMoveToDashboard(string gameId, string figureClasses, string oldAddressFigure, string newAddressFigure)
        {
            var figure = figureClasses.Split("-")[2];
            var currentUserName = this.Context.User.Identity.Name;
            var currentMove = $"{currentUserName}: {figure} {oldAddressFigure} to {newAddressFigure}";

            await this.movesService.AddMoveToDbAsync(currentMove, gameId);
            var currentGame = await this.gamesService.GetHubGameViewModelByGameIdAsync(gameId);

            if (currentUserName == currentGame.HostUsername)
            {
                await Clients.Client(currentGame.HostConnectionId).SendAsync("AddNewMoveToDashboard", currentMove, GlobalConstants.HomeColor);
                await Clients.Client(currentGame.GuestConnectionId).SendAsync("AddNewMoveToDashboard", currentMove, GlobalConstants.AwayColor);
            }
            else if (currentUserName == currentGame.GuestUsername)
            {
                await Clients.Client(currentGame.HostConnectionId).SendAsync("AddNewMoveToDashboard", currentMove, GlobalConstants.AwayColor);
                await Clients.Client(currentGame.GuestConnectionId).SendAsync("AddNewMoveToDashboard", currentMove, GlobalConstants.HomeColor);
            }
        }

        public async Task AddHostConnectionIdToGame(string gameId)
        {
            var hostConnectionId = this.Context.ConnectionId;
            await this.gamesService.AddHostConnectionIdToGameAsync(gameId, hostConnectionId);
        }

        public async Task AddGuestConnectionIdToGame(string gameId)
        {
            var guestConnectionId = this.Context.ConnectionId;
            await this.gamesService.AddGuestConnectionIdToGameAsync(gameId, guestConnectionId);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            //var userId = this.userManager.GetUserId(this.Context.User);
            var connectionId = this.Context.ConnectionId;
            var abandonedGame = await this.gamesService.GetGameByConnectionIdAndIsActiveStatusAsync(connectionId);

            if (abandonedGame != null)
            {
                var abandonedGameId = abandonedGame.Id;
                await this.Clients.All.SendAsync("DeleteGame", abandonedGameId);
                await this.gamesService.MakeGameInActiveAsync(abandonedGameId);
            }

            //var finishedGame = this.db.Games
            //    .FirstOrDefault(x => (x.HostConnectionId == connectionId || x.GuestConnectionId == connectionId) && x.IsActive == false);

            //if (finishedGame != null)
            //{
            //    var opponentConnectionId = string.Empty;
            //    if (connectionId == finishedGame.HostConnectionId)
            //    {
            //        opponentConnectionId = finishedGame.GuestConnectionId;
            //    }
            //    else if (connectionId == finishedGame.GuestConnectionId)
            //    {
            //        opponentConnectionId = finishedGame.HostConnectionId;
            //    }

            //    await this.Clients.Client(opponentConnectionId).SendAsync("ActivategameEndModal");
            //}
            ////da sloja igrata inactive
            //Console.WriteLine($"{this.Context.ConnectionId}");
            //Console.WriteLine("here");           
        }
    }
}
