using Chess.Data.Models;
using Chess.Services.Paging;
using Chess.Web.ViewModels.InputModels.Games;
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

        Task<GameDetailsViewModel> GetGameDetailsViewModelAsync(string gameId);

        Task<Game> GetGameByIdAsync(string gameId);

        Task DeleteGameByIdAsync(string gameId);

        Task<string> GetActiveGameIdByUserIdAsync(string userId);

        Task<List<int>> GetTheCountForTheCreatedGamesForTheLastTenDaysAsync();

        Task<string> GetOpponentUserConnectionIdAsync(string currentUserConnectionId, string gameId);

        Task<List<GameAllViewModel>> GetGameAllViewModelsAsync();

        Task<GamesViewModel> GetGamesViewModelAsync();

        Task<GameViewModel> GetGameViewModelAsync(GameInputViewModel input);

        Task<GameViewModel> GetEnteringGameViewModelAsync(string id);

        Task AddHostConnectionIdToGameAsync(string gameId, string hostConnectionId);

        Task AddGuestConnectionIdToGameAsync(string gameId, string guestConnectionId);

        Task<HubGameViewModel> GetHubGameViewModelByGameIdAsync(string gameId);

        Task<PaginatedList<MyGameViewModel>> GetMyGameViewModelsAsync(int pageNumber, int pageSize);

        Task<Game> GetGameByConnectionIdAndIsActiveStatusAsync(string connectionId);

        Task MakeGameInActiveAsync(string gameId);
    } 
}
