namespace Chess.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Chess.Web.ViewModels.ViewModels.Messages;

    public interface IMessagesService
    {
        Task AddMessageToDbAsync(string content, string gameId);

        Task<List<MessageViewModel>> GetGameAllMessagesViewModelByGameIdAsync(string gameId);
    }
}
