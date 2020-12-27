namespace Chess.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Chess.Common;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;

    [Authorize]
    public class FavouritesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFavouritesService favouritesService;
        private readonly IVideosService videosService;

        public FavouritesController(UserManager<ApplicationUser> userManager, IFavouritesService favouritesService, IVideosService videosService)
        {
            this.userManager = userManager;
            this.favouritesService = favouritesService;
            this.videosService = videosService;
        }

        public async Task<IActionResult> MyFavourites(int? pageNumber)
        {
            var loggedInUserId = userManager.GetUserId(User);

            var favouriteVideosViewModels = await videosService.GetFavouriteVideoViewModelsAsync(pageNumber ?? GlobalConstants.DefaultPageNumber, GlobalConstants.DefaultVideoPageSize);

            return View(favouriteVideosViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int videoId)
        {
            bool isAdded = await this.favouritesService.AddToFavoritesAsync(videoId);

            return Json(isAdded);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int videoId)
        {
            bool isRemoved = await this.favouritesService.RemoveFromFavoritesAsync(videoId);

            return Json(isRemoved);
        }
    }
}
