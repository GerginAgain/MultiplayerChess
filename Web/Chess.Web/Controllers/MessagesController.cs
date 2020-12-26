namespace Chess.Web.Controllers
{
    using Chess.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MessagesController : Controller
    {
        private readonly IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public async Task<IActionResult> MyGameChat(string id)
        {
            var messageViewModels = await this.messagesService.GetGameAllMessagesViewModelByGameIdAsync(id);
            return View(messageViewModels);
        }
    }
}
