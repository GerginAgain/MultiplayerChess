using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Web.ViewModels.ViewModels.Videos
{
     public class VideoAllViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public bool IsInFavourites { get; set; }
    }
}
