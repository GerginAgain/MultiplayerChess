using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Web.ViewModels.ViewModels.Videos
{
    public class LatestThreeAddedVideosViewModel
    {
        public IList<VideoViewModel> Videos { get; set; } = new List<VideoViewModel>();
    }
}
