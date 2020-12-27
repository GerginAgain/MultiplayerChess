namespace Chess.Web.ViewModels.ViewModels.Videos
{
    using System;

    public class DeletedVideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public string PictureLink { get; set; }
    }
}
