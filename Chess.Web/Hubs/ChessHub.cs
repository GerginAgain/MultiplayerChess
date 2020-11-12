using Chess.Data;
using Chess.Web.ViewModels;
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

        public async Task SendMessage(string startId, string targetId, int gameId)
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

            Console.WriteLine("opponentConectionId is " + opponentUserId);
            Console.WriteLine("gameId is " + currentGame.Id);
            Console.WriteLine("gameId is " + currentGame.HostConnectionId);
            Console.WriteLine("gameId is " + currentGame.GuestConnectionId);
            Console.WriteLine("currentUserConnectionId is " + currentUserConnectionId);

            await Clients.Client(opponentUserId).SendAsync("ReceiveMessage", startId, targetId);

        }

        public async Task SendNewGame(string name, string color)
        {
            var gameId = this.db.Games.First(x => x.Name == name).Id;
            var colorInString = Enum.GetName(typeof(Color), int.Parse(color));
            await Clients.Others.SendAsync("AddNewGame", name, colorInString, gameId);
        }

        public void AddHostConnectionIdToGame(int gameId)
        {
            //Console.WriteLine("gameId = " + gameId);
            var hostConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
            currentGame.HostConnectionId = hostConnectionId;
            this.db.SaveChanges();
        }

        public void AddGuestConnectionIdToGame(int gameId)
        {
            //Console.WriteLine("gameId = " + gameId);
            var guestConnectionId = this.Context.ConnectionId;
            var currentGame = this.db.Games.First(x => x.Id == gameId);
            currentGame.GuestConnectionId = guestConnectionId;
            this.db.SaveChanges();
        }
    }
}
