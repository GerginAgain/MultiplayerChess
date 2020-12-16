using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Web.ViewModels.ViewModels.Videos
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string PictureName{ get; set; }

        public string PictureLink{ get; set; }

        public bool IsInFavourites { get; set; }
    }
}
