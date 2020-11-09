﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Web.ViewModels
{
    public class GameInputViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Color of the figures")]
        public Color Color { get; set; }

        public string HostConnectionId { get; set; }
    }
}
