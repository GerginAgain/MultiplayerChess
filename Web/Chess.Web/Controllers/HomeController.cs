namespace Chess.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Chess.Web.ViewModels;
    using Chess.Data;
    using Chess.Services.Interfaces;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChessDbContext db;
        private readonly IVideosService videosService;

        public HomeController(ILogger<HomeController> logger, ChessDbContext db, IVideosService videosService)
        {
            _logger = logger;
            this.db = db;
            this.videosService = videosService;
        }

        public async Task<IActionResult> Index()
        {
            var latestThreeAddedVideosViewModel = await this.videosService.GetLatestThreeVideosAsync();
            return View(latestThreeAddedVideosViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
