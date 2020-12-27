namespace Chess.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Chess.Common;
    using Chess.Services.Interfaces;

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
