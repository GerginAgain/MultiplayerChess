namespace Chess.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;  
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Chess.Common;
    using Chess.Web.ViewModels.InputModels.Videos;
    using Chess.Services.Interfaces;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class VideosController : Controller
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
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

        public async Task<IActionResult> AllActiveVideos(int? pageNumber)
        {
            var allVideosViewModel = await this.videosService.GetAllActiveVideosViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultAdminVideoPageSize);

            return this.View(allVideosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int videoId)
        {
            var isDeleted = await this.videosService.DeleteVideoByIdAsync(videoId);
            return this.Json(isDeleted);
        }

        public async Task<IActionResult> Deleted(int? pageNumber)
        {
            var allDeletedVideoViewModels = await this.videosService.GetAllDeletedVideosViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultAdminVideoPageSize);

            return this.View(allDeletedVideoViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int videoId)
        {
            var isDeleted = await this.videosService.RestoreVideoByIdAsync(videoId);
            return this.Json(isDeleted);
        }
    }
}
