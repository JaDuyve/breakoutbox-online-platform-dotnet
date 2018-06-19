using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using HubCallerContext = Microsoft.AspNet.SignalR.Hubs.HubCallerContext;
using HubConnectionContext = Microsoft.AspNet.SignalR.Hubs.HubConnectionContext;


namespace BreakOutBoxAuth.hubs
{
    public class AppHub : Hub, IAppHub
    {
        private IDictionary<string, string> _clients = new Dictionary<string, string>();

        private IHub _hubImplementation;
/*

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", "joined");
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("SendAction", "left");
        }*/

        public  void ActivateLoungeStartButton(String sessieName)
        {
            Console.WriteLine("activatebutton");
            Clients.Group(sessieName).SendAsync("ActivateStartButton", "activate");
        }

        public void AddClient(String key, String connectionId)
        {
            _clients.Add(key, connectionId);
        }

        public  Task JoinRoom(string roomName)
        {
            Console.WriteLine(roomName + "joined");
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            //return Groups.Add(Context.ConnectionId, roomName);
        }

        public  Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }


        public Task OnConnected()
        {
            return _hubImplementation.OnConnected();
        }

        public Task OnReconnected()
        {
            return _hubImplementation.OnReconnected();
        }

        public Task OnDisconnected()
        {
            return _hubImplementation.OnDisconnected();
        }

        public HubCallerContext Context { get; set; }
        public HubConnectionContext Clients { get; set; }
        public IGroupManager Groups { get; set; }
        public void Dispose()
        {
            _hubImplementation.Dispose();
        }
    }
}