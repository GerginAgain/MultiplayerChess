namespace Chess.Services.Interfaces
{
    using Chess.Web.ViewModels.ViewModels.Messages;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessagesService
    {
        Task AddMessageToDbAsync(string content, string gameId);

        Task<List<MessageViewModel>> GetGameAllMessagesViewModelByGameIdAsync(string gameId);
    }
}
