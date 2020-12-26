namespace Chess.Web.ViewModels.ViewModels.Messages
{
    using System;

    public class MessageViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }
    }
}
