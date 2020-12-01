using Chess.Data;
using Chess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chess.Services
{
    public class GamesService : IGamesService
    {
        private readonly ChessDbContext context;

        public GamesService(ChessDbContext context)
        {
            this.context = context;
        }

        public async Task<int> GetCountOfAllGamesAsync()
        {
            var allGamesCount = await context.Games.CountAsync();

            return allGamesCount;
        }
    }
}
