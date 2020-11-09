using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Web.ViewModels
{
    public class GamesViewModel
    {
        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}
