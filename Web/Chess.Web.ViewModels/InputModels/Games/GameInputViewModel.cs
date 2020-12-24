using System.ComponentModel.DataAnnotations;
using Chess.Web.ViewModels.InputModels.Enums;

namespace Chess.Web.ViewModels.InputModels.Games
{
    public class GameInputViewModel
    {
        [Required]     
        [MinLength(5, ErrorMessage = "Name must be more than 5 letters")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Color of the figures")]
        public Color Color { get; set; }
    }
}
