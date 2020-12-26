namespace Chess.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IMessagesService
    {
        Task AddMessageToDbAsync(string content, string gameId);
    }
}
