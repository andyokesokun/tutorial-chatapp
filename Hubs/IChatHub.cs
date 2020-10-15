using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public interface IChatHub
    {
        Task ReceivedMessage(MessageModel messageModel);
    }
}
