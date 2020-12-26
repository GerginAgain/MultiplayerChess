using Chess.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chess.Data.Models
{
    public class Game : BaseModel<string>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public bool IsActive { get; set; } = true;

        public string HostConnectionId { get; set; }

        public string GuestConnectionId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string HostId { get; set; }
        public virtual ApplicationUser Host { get; set; }

        [ForeignKey("ApplicationUser")]
        public string GuestId { get; set; }
        public virtual ApplicationUser Guest { get; set; }

        public virtual ICollection<Move> Moves { get; set; }
    }
}
