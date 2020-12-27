namespace Chess.Services
{
    using Chess.Common;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class FavouritesService : IFavouritesService
    {
        private readonly ChessDbContext db;
        private readonly IUsersService usersService;

        public FavouritesService(ChessDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public async Task<bool> AddToFavoritesAsync(int videoId)
        {
            var currentUser = await usersService.GetCurrentUserAsync();

            if (currentUser == null)
            {
                throw new InvalidOperationException(GlobalConstants.CurrentUserIsNullErrorMessage);
            }

            if (!await this.db.Videos.AnyAsync(x => x.Id == videoId))
            {
                throw new ArgumentException(GlobalConstants.InvalidVideoIdErrorMessage);
            }

            var isInFavorites = currentUser.UserFavouriteVideos
                .Any(x => x.VideoId == videoId);

            if (isInFavorites)
            {
                throw new InvalidOperationException(GlobalConstants.VideoIsAlreadyInFavoritesErrorMessage);
            }

            await CreateUserFavoriteVideoAsync(videoId, currentUser.Id);
            return true;
        }

        public async Task<bool> RemoveFromFavoritesAsync(int videoId)
        {
            var currentUser = await this.usersService.GetCurrentUserAsync();

            if (currentUser == null)
            {
                throw new InvalidOperationException(GlobalConstants.CurrentUserIsNullErrorMessage);
            }

            if (!await this.db.Videos.AnyAsync(x => x.Id == videoId))
            {
                throw new ArgumentException(GlobalConstants.InvalidVideoIdErrorMessage);
            }

            var isInFavorites = currentUser.UserFavouriteVideos
                .Any(x => x.VideoId == videoId);

            if (!isInFavorites)
            {
                throw new InvalidOperationException(GlobalConstants.VideoIsNotInFavoritesListErrorMessage);
            }

            await RemoveUserFavoriteVideoAsync(videoId, currentUser.Id);
            return true;
        }

        public async Task CreateUserFavoriteVideoAsync(int videoId, string currentUserId)
        {
            var userFavouriteVideo = new UserFavouriteVideo
            {
                VideoId = videoId,
                ApplicationUserId = currentUserId
            };

            await this.db.UserFavouriteVideos.AddAsync(userFavouriteVideo);
            await this.db.SaveChangesAsync();
        }

        public async Task RemoveUserFavoriteVideoAsync(int videoId, string currentUserId)
        {
            var sellMeUserFavoriteProduct = this.db.UserFavouriteVideos.First(x => x.VideoId == videoId && x.ApplicationUserId == currentUserId);

            this.db.Remove(sellMeUserFavoriteProduct);
            await this.db.SaveChangesAsync();
        }
    }
}
