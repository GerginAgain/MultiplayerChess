using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Web.ViewModels.ViewModels.Games
{
    public class GameDetailsViewModel
    {
        public string Name { get; set; }

        public string HostFiguresColor { get; set; }

        public DateTime CreatedOn { get; set; }

        public string HostUsername { get; set; }

        public string HostConnectionId { get; set; }

        public string GuestConnectionId { get; set; }
    }
}
