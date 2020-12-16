using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IFavouritesService
    {
        Task<bool> AddToFavoritesAsync(int videoId);

        Task<bool> RemoveFromFavoritesAsync(int videoId);

        Task CreateUserFavoriteVideoAsync(int videoId, string currentUserId);

        Task RemoveUserFavoriteVideoAsync(int videoId, string currentUserId);
    }
}
