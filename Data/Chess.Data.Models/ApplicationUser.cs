using Chess.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Chess.Data.Models
{
    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
