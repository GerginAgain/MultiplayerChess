namespace Chess.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Chess.Data.Common;

    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.UserFavouriteVideos = new HashSet<UserFavouriteVideo>();
        }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<UserFavouriteVideo> UserFavouriteVideos { get; set; }
    }
}
