﻿namespace Chess.Web.ViewModels.ViewModels.Users
{
    using System;

    public class BlockedUserAllViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
