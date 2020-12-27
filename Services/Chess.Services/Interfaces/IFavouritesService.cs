namespace Chess.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IFavouritesService
    {
        Task<bool> AddToFavoritesAsync(int videoId);

        Task<bool> RemoveFromFavoritesAsync(int videoId);

        Task CreateUserFavoriteVideoAsync(int videoId, string currentUserId);

        Task RemoveUserFavoriteVideoAsync(int videoId, string currentUserId);
    }
}
