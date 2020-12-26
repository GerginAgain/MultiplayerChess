namespace Chess.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    using Chess.Common;
    using Chess.Data;
    using Chess.Services.Interfaces;

    public class ChessHub : Hub
    {
        private readonly ChessDbContext db;
        private readonly IGamesService gamesService;
        private readonly IMovesService movesService;
        private readonly IMessagesService messagesService;

        public ChessHub(ChessDbContext db, IGamesService gamesService, IMovesService movesService, IMessagesService messagesService)
        {
            this.db = db;
            this.gamesService = gamesService;
            this.movesService = movesService;
            this.messagesService = messagesService;
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
    }
}
