namespace Chess.Services
{
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public class MovesService : IMovesService
    {
        private readonly ChessDbContext db;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<ApplicationUser> userManager;

        public MovesService(ChessDbContext db, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.httpContext = httpContext;
            this.userManager = userManager;
        }

        public async Task AddMoveToDbAsync(string title, string gameId)
        {
            var playerId = this.userManager.GetUserId(this.httpContext.HttpContext.User);

            var move = new Move
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                ApplicationUserId = playerId,
                GameId = gameId,
            };

            await this.db.Moves.AddAsync(move);
            await this.db.SaveChangesAsync();
        }
    }
}
