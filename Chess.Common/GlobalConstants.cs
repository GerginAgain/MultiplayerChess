using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Common
{
    public static class GlobalConstants
    {
        public const string InvalidUserIdErrorMessage = "User with the given id doesn't exist!";
        public const string InvalidGameIdErrorMessage = "Game with the given id doesn't exist!";

        public const string CurrentUserIsNullErrorMessage = "Current user can't be null";
        public const string InvalidVideoIdErrorMessage = "Ad with the given id doesn't exist!";
        public const string VideoIsAlreadyInFavoritesErrorMessage = "The given ad is already added to favorites!";
        public const string VideoIsNotInFavoritesListErrorMessage = "The given ad isn't in the favorites list!";

        public const string AdministratorRoleName = "Administrator";

        public const int CreatedGamesStatisticDaysCount = 10;

        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 10;
        public const int DefaultVideoPageSize = 6;
        public const int DefaultAdminVideoPageSize = 5;
    }
}
