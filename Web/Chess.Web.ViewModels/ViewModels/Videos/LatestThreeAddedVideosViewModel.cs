namespace Chess.Web.ViewModels.ViewModels.Videos
{
    using System.Collections.Generic;

    public class LatestThreeAddedVideosViewModel
    {
        public IList<VideoViewModel> Videos { get; set; } = new List<VideoViewModel>();
    }
}
