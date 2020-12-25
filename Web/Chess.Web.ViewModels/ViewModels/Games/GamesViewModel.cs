namespace Chess.Web.ViewModels.ViewModels.Games
{
    using System.Collections.Generic;

    public class GamesViewModel
    {
        public IEnumerable<GameAllViewModel> Games { get; set; } = new List<GameAllViewModel>();
    }
}
