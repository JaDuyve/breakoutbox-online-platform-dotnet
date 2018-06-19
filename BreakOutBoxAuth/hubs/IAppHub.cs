using System;
using System.Threading.Tasks;

namespace BreakOutBoxAuth.hubs
{
    public interface IAppHub
    {
        void ActivateLoungeStartButton(String sessieName);
        void AddClient(String key, String connectionId);
        Task JoinRoom(string roomName);
        Task LeaveRoom(string roomName);
    }
}