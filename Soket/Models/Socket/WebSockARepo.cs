using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebSocketManager;

namespace Soket.Models.Socket
{
    public static class WebSockARepo
    {
        /* Use SingleTone*/

        private static Dictionary<string, SocketInfo> _sockMap;

        static WebSockARepo()
        {
            _sockMap = new Dictionary<string, SocketInfo>();
        }


        public static void AddSocket(string socketId, WebSocket socket)
        {
            // Set Infomation
            var x = socket.SubProtocol;

            var info = new SocketInfo()
            {
                SocketId = socketId
            };

            // Add Socket Data
            _sockMap.TryAdd(socketId, info);


        }

    }
}
