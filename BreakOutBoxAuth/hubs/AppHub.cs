using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.ApplicationInsights.HostingStartup;


namespace BreakOutBoxAuth.hubs
{
    public class AppHub :Hub
    {
        private IDictionary<string, string> _clients = new Dictionary<string, string>();
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
        }

        public  Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        
    }
}