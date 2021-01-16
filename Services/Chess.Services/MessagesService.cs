namespace Chess.Services
{
    using AutoMapper;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Messages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MessagesService : IMessagesService
    {
        private readonly ChessDbContext db;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public MessagesService(ChessDbContext db, IMapper mapper, IUsersService usersService)
        {
            this.db = db;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task AddMessageToDbAsync(string content, string gameId)
        {
            var player = await this.usersService.GetCurrentUserAsync();
            var playerId = player.Id;

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

        public async Task<List<MessageViewModel>> GetGameAllMessagesViewModelByGameIdAsync(string gameId)
        {
            var messagesFromDb = this.db.Messages
                .Where(x => x.GameId == gameId)
                .OrderBy(x => x.CreatedOn);

            var messagesViewModel = await this.mapper.ProjectTo<MessageViewModel>(messagesFromDb).ToListAsync();
            return messagesViewModel;
        }
    }
}
