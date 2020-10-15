using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub: Hub<IChatHub>
    {
        public async Task SendMessage(string username, string message) {

            var messageModel = new MessageModel
            {
                User = username,
                Message = message,
            };

            await Clients.All.ReceivedMessage(messageModel);
        }
    }
}
