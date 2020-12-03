using Chess.Services.Paging;
using Chess.Web.ViewModels.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Chess.Services.Interfaces
{
    public interface IUsersService
    {
        Task<int> GetCountOfAllUsersAsync();

        Task<PaginatedList<UserAllViewModel>> GetAllUserViewModelsAsync(int pageNumber, int pageSize);

        Task<bool> BlockUserByIdAsync(string userId);

        Task<PaginatedList<BlockedUserAllViewModel>> GetAllBlockedUserViewModels(int pageNumber, int pageSize);

        Task<bool> UnblockUserByIdAsync(string userId);
    }
}
