using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Web.ViewModels.ViewModels.Users
{
    public class UserAllViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
