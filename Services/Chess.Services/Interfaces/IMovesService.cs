namespace Chess.Services.Interfaces
{   
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Chess.Web.ViewModels.ViewModels.Moves;

    public interface IMovesService
    {
        Task AddMoveToDbAsync(string title, string gameId);

        Task<List<MoveViewModel>> GetGameAllMovesViewModelByGameIdAsync(string gameId);
    }
}
