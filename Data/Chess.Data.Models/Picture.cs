namespace Chess.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Chess.Data.Common;

    public class Picture : BaseModel<int>, IDeletableEntity
    {
        [Required]
        [MinLength(5, ErrorMessage = "Picture name must be more than 5 letters")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
