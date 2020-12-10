using Chess.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chess.Data.Models
{
    public class Picture : BaseModel<int>, IDeletableEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
