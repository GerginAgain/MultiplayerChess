namespace Chess.Services
{
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public class MessagesService : IMessagesService
    {
        private readonly ChessDbContext db;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<ApplicationUser> userManager;

        public MessagesService(ChessDbContext db, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.httpContext = httpContext;
            this.userManager = userManager;
        }

        public async Task AddMessageToDbAsync(string content, string gameId)
        {
            var playerId = this.userManager.GetUserId(this.httpContext.HttpContext.User);

            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                Content = content,
                GameId = gameId,
                ApplicationUserId = playerId,
            };

            await this.db.Messages.AddAsync(message);
            await this.db.SaveChangesAsync();
        }
    }
}
