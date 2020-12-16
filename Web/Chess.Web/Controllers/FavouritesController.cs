using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Data.Models;
using Chess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFavouritesService favouritesService;

        public FavouritesController(UserManager<ApplicationUser> userManager, IFavouritesService favouritesService)
        {
            this.userManager = userManager;
            this.favouritesService = favouritesService;
        }

        //public async Task<IActionResult> MyFavorites(int? pageNumber)
        //{
        //    var loggedInUserId = userManager.GetUserId(User);

        //    var favoriteAdsViewModels = await adsService.GetFavoriteAdsViewModelsAsync(loggedInUserId, pageNumber ?? DefaultPageNumber, DefaultPageSize);

        //    return View(favoriteAdsViewModels);
        //}

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
