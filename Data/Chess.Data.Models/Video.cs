namespace Chess.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Chess.Data.Common;

    public class Video : BaseModel<int>, IDeletableEntity
    {
        public Video()
        {
            this.UserFavouriteVideos = new HashSet<UserFavouriteVideo>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Video name must be more than 5 letters")]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Link { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey("Picture")]
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public virtual ICollection<UserFavouriteVideo> UserFavouriteVideos { get; set; }
    }
}

