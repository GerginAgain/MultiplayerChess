namespace Chess.Services.Interfaces
{
    using System;
    using Chess.Data.Models;
    using Chess.Services.Paging;
    using Chess.Web.ViewModels.InputModels.Games;
    using Chess.Web.ViewModels.ViewModels.Moves;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMovesService
    {
        Task AddMoveToDbAsync(string title, string gameId);

        Task<List<MoveViewModel>> GetGameAllMovesViewModelByGameIdAsync(string gameId);
    }
}
