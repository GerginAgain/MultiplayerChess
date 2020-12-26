namespace Chess.Services
{
    using AutoMapper;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Chess.Web.ViewModels.ViewModels.Messages;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MessagesService : IMessagesService
    {
        private readonly ChessDbContext db;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public MessagesService(ChessDbContext db, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.db = db;
            this.httpContext = httpContext;
            this.userManager = userManager;
            this.mapper = mapper;
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
