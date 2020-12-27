namespace Chess.Web.ViewModels.InputModels.Videos
{
    using System.ComponentModel.DataAnnotations;

    public class AddVideoInputModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Video name must be more than 5 letters")]
        [MaxLength(20)]
        [Display(Name = "Video Title")]
        public string VideoTitle { get; set; }

        [Required]
        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Picture name must be more than 5 letters")]
        [MaxLength(20)]
        [Display(Name = "Picture Name")]
        public string PictureName { get; set; }

        [Required]
        [Display(Name = "Picture Link")]
        public string PictureLink { get; set; }
    }
}
