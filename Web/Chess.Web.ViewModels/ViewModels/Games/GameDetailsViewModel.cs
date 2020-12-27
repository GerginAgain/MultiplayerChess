namespace Chess.Web.ViewModels.ViewModels.Games
{
    using System;

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
