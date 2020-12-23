using Chess.Data;
using Chess.Web.ViewModels.InputModels.Enums;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Chess.Web.Hubs
{
    public class ChessHub : Hub
    {
        private readonly ChessDbContext db;

        public ChessHub(ChessDbContext db)
        {
            this.db = db;
        }

        public async Task Send(string message, int gameId)
        {
            var currentUserConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
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
            await this.Clients.Client(opponentUserId).SendAsync("NewMessage", userName, message);
        }

        public async Task SendNewMove(string startId, string targetId, int gameId, string figureClasses, string oldAddressFigure, string newAddressFigure) //
        {
            var currentUserConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
            var opponentUserId = string.Empty;

            if (currentGame.HostConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.GuestConnectionId;
            }
            else if (currentGame.GuestConnectionId == currentUserConnectionId)
            {
                opponentUserId = currentGame.HostConnectionId;
            }

            Console.WriteLine(figureClasses.Split("-")[2]);//
            var figure = figureClasses.Split("-")[2];
            Console.WriteLine(oldAddressFigure);//
            Console.WriteLine(newAddressFigure);//
            var currentUserName = this.Context.User.Identity.Name;
            var currentMove = $"{currentUserName}: {figure} {oldAddressFigure} to {newAddressFigure}";
            await Clients.Client(currentGame.HostConnectionId).SendAsync("AddNewMoveToDashboard", currentMove);
            await Clients.Client(currentGame.GuestConnectionId).SendAsync("AddNewMoveToDashboard", currentMove);

            await Clients.Client(opponentUserId).SendAsync("ReceiveNewMove", startId, targetId);
        }

        public async Task SendNewGame(string name, string color)
        {
            var gameId = this.db.Games.First(x => x.Name == name).Id;
            var colorInString = Enum.GetName(typeof(Color), int.Parse(color));
            await Clients.Others.SendAsync("AddNewGame", name, colorInString, gameId);
        }

        public void AddHostConnectionIdToGame(int gameId)
        {
            var hostConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
            currentGame.HostConnectionId = hostConnectionId;
            this.db.SaveChanges();
        }

        public void AddGuestConnectionIdToGame(int gameId)
        {
            var guestConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
            currentGame.GuestConnectionId = guestConnectionId;
            this.db.SaveChanges();
        }
    }
}
