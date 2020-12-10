using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Common;
using Chess.Data.Models;
using Chess.Web.ViewModels.InputModels.Videos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Chess.Data;
using Microsoft.EntityFrameworkCore;
using Chess.Services.Interfaces;

namespace Chess.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class VideosController : Controller
    {
        private readonly ChessDbContext db;
        private readonly IVideosService videosService;

        public VideosController(ChessDbContext db, IVideosService videosService)
        {
            this.db = db;
            this.videosService = videosService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVideoInputModel input)
        {
            await this.videosService.CreateVideoAsync(input);
            return this.Redirect("/");
        }
    }
}
