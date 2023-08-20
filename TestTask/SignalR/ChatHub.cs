using Microsoft.AspNetCore.SignalR;
using TestTask.Controllers.Messages;
using TestTask.Models;
using TestTask;

namespace TestTask.SignalR
{
    public class ChatHub:Hub
    {
        public async Task Send(Message mes)
        {
            await this.Clients.All.SendAsync("Receive", mes);
        }
    }
}
