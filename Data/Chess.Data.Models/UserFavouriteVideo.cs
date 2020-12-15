using Chess.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Data.Models
{
    public class UserFavouriteVideo : BaseModel<int>
    {
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
