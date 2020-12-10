using Chess.Data.Models;
using Chess.Services.Paging;
using Chess.Web.ViewModels.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IGamesService
    {
        Task<int> GetCountOfAllGamesAsync();

        Task<PaginatedList<ActiveGameAllViewModel>> GetAllActiveGamesViewModelsAsync(int pageNumber, int pageSize);

        Task<GameDetailsViewModel> GetGameDetailsViewModelAsync(int gameId);

        Task<Game> GetGameByIdAsync(int gameId);

        Task DeleteGameByIdAsync(int gameId);

        Task<int> GetActiveGameIdByUserIdAsync(string userId);

        Task<List<int>> GetTheCountForTheCreatedGamesForTheLastTenDaysAsync();
    }
}
