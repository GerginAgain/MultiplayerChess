using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chess.Common;
using Chess.Services.Interfaces;

namespace Chess.Web.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideosService videosService;

        public VideosController( IVideosService videosService)
        {
            this.videosService = videosService;
        }

        public async Task<IActionResult> AllVideos(int? pageNumber)
        {
            var allVideosViewModel = await videosService.GetAllVideosViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultVideoPageSize);

            return View(allVideosViewModel);
        }
    }
}
