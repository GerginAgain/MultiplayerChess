namespace Chess.Services.Interfaces
{
    using System.Threading.Tasks;
    using Chess.Services.Paging;
    using Chess.Web.ViewModels.ViewModels.Users;
    using Chess.Data.Models;

    public interface IUsersService
    {
        Task<int> GetCountOfAllUsersAsync();

        Task<PaginatedList<UserAllViewModel>> GetAllUserViewModelsAsync(int pageNumber, int pageSize);

        Task<bool> BlockUserByIdAsync(string userId);

        Task<PaginatedList<BlockedUserAllViewModel>> GetAllBlockedUserViewModels(int pageNumber, int pageSize);

        Task<bool> UnblockUserByIdAsync(string userId);

        Task<ApplicationUser> GetUserByIdAsync(string id);

        Task<ApplicationUser> GetCurrentUserAsync();

        Task<string> GetUserHostConnectionIdByGameIdAsync(string gameId);
    }
}
