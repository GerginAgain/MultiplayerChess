using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Web.Hubs
{
    public class ChessHub : Hub
    {
        public async Task SendMessage(string startId, string targetId)
        {
            await Clients.Others.SendAsync("ReceiveMessage", startId, targetId);
            Console.WriteLine(startId + "and" + targetId);
        }
    }
}
