namespace Chess.Services
{
    using AutoMapper;      
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Moves;

    public class MovesService : IMovesService
    {
        private readonly ChessDbContext db;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public MovesService(ChessDbContext db, IMapper mapper, IUsersService usersService)
        {
            this.db = db;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task AddMoveToDbAsync(string title, string gameId)
        {
            var player = await this.usersService.GetCurrentUserAsync();
            var playerId = player.Id;

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
