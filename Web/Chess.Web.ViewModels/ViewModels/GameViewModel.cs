using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Web.ViewModels.ViewModels
{
    public class GameViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string HostConnectionId { get; set; }

        public string HostName { get; set; }

        public string GuestConnectionId { get; set; }

        public string GuestName { get; set; }

    }
}
