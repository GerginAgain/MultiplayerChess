namespace Chess.Web.ViewModels.ViewModels.Games
{
    using System;

    public class MyGameViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string HostName { get; set; }

        public string HostFigureColors { get; set; }

        public string GuestName { get; set; }
    }
}
