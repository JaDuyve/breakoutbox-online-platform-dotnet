using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.ApplicationInsights.HostingStartup;

namespace BreakOutBoxAuth.hubs
{
    public class hub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewButtonToPage(name, message);
        }
    }
}