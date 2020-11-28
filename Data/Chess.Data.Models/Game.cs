using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string HostConnectionId { get; set; }

        public string GuestConnectionId { get; set; }

    }
}
