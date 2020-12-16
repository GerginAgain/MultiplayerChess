using Chess.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chess.Data.Models
{
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
