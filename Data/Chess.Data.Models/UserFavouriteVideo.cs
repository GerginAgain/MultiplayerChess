namespace Chess.Data.Models
{
    using Chess.Data.Common;

    public class UserFavouriteVideo : BaseModel<int>
    {
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
