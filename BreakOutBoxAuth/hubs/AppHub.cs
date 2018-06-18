using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.ApplicationInsights.HostingStartup;

namespace BreakOutBoxAuth.hubs
{
    public class AppHub : Hub
    {
        public async void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
//            Clients.All.addNewButtonToPage(name, message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}