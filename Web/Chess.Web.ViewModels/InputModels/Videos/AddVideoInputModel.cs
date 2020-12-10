using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chess.Web.ViewModels.InputModels.Videos
{
    public class AddVideoInputModel
    {
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "Video Title")]
        public string VideoTitle { get; set; }

        [Required]
        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "Picture Name")]
        public string PictureName { get; set; }

        [Required]
        [Display(Name = "Picture Link")]
        public string PictureLink { get; set; }
    }
}
