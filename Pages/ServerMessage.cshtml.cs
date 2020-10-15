using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp
{
    public class ServerMessageModel : PageModel
    {
        private readonly IHubContext<ChatHub, IChatHub> _hubContext;

        public ServerMessageModel(IHubContext<ChatHub, IChatHub> hubContext)
        {
             _hubContext = hubContext;
        }
        public async Task OnGet()
        {
            var messageModel = new MessageModel
            {
                User = "Server",
                Message = "Hello from server"
            };

           await _hubContext.Clients.All.ReceivedMessage(messageModel);
           
        }
    }
}