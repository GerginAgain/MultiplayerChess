using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chess.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string HostConnectionId { get; set; }

        public string GuestConnectionId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string HostId { get; set; }
        public virtual ApplicationUser Host { get; set; }

        [ForeignKey("ApplicationUser")]
        public string GuestId { get; set; }
        public virtual ApplicationUser Guest { get; set; }
    }
}
