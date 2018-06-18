using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.ApplicationInsights.HostingStartup;
using HubCallerContext = Microsoft.AspNet.SignalR.Hubs.HubCallerContext;
using IGroupManager = Microsoft.AspNet.SignalR.IGroupManager;

namespace BreakOutBoxAuth.hubs
{
    public class AppHub :Hub
    {
        private IDictionary<string, string> _clients = new Dictionary<string, string>();

        public async void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
//            Clients.All.addNewButtonToPage(name, message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task ActivateLoungeStartButton(String sessieName)
        {
            Console.WriteLine("activatebutton");
            await Clients.Group(sessieName).SendAsync("ActivateStartButton");
        }

        public void AddClient(String key, String connectionId)
        {
            _clients.Add(key, connectionId);
        }

        public  Task JoinRoom(string roomName)
        {
            Console.WriteLine(roomName + "joined");
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public  Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        /*public Task OnConnected()
        {
            return base.OnConnectedAsync();
        }

        public Task OnReconnected()
        {
return base.OnDisconnectedAsync()        }

        public Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnectedAsync(stopCalled);
        }*/

        /*public HubCallerContext Context { get; set; }
        public IHubCallerConnectionContext<dynamic> Clients { get; set; }
        public IGroupManager Groups { get; set; }*/
    }
}