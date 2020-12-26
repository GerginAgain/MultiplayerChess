namespace Chess.Services
{
    using AutoMapper;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Moves;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MovesService : IMovesService
    {
        private readonly ChessDbContext db;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public MovesService(ChessDbContext db, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.db = db;
            this.httpContext = httpContext;
            this.userManager = userManager;
            this.mapper = mapper;
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

        public async Task<List<MoveViewModel>> GetGameAllMovesViewModelByGameIdAsync(string gameId)
        {
            var movesFromDb = this.db.Moves
                .Where(x => x.GameId == gameId)
                .OrderBy(x => x.CreatedOn);

            var moveViewModels = await this.mapper.ProjectTo<MoveViewModel>(movesFromDb).ToListAsync();
            return moveViewModels;
        }
    }
}
