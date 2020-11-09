using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Web.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string HostConnectionId { get; set; }

        public string GuestConnectionId { get; set; }

    }
}
