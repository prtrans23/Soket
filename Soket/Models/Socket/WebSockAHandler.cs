using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.WebSockets;
using WebSocketManager;
using WebSocketManager.Common;
using Soket.Models.myMessage;

namespace Soket.Models.Socket
{
    public class WebSockAHandler : WebSocketHandler
    {
        /* Import Dll Files WebSocketManager */

        public WebSockAHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager, new ControllerMethodInvocationStrategy())
        {
            ((ControllerMethodInvocationStrategy)MethodInvocationStrategy).Controller = this;
           
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var socketId = WebSocketConnectionManager.GetId(socket);

            var message = InfoMessageFactory.GetSocketId(socketId);

             await SendMessageToAllAsync(message);
        }

        // this method can be called from a client, doesn't return anything.
        public async Task SendMessage(WebSocket socket, string message)
        {
            // chat command.
            if (message == "/GetIP")
            {
                await AskClientIP(socket);
            }
            else
            {
                await InvokeClientMethodToAllAsync("receiveMessage", WebSocketConnectionManager.GetId(socket), message);
            }
        }

        public string GetIP(WebSocket socket, string ip)
        {
            var message = InfoMessageFactory.GetClientIp(ip);
            return message;
        }

        private async Task AskClientIP(WebSocket socket)
        {
            string id = WebSocketConnectionManager.GetId(socket);
            try
            {
                string result = await InvokeClientMethodAsync<string, string>(id, "IP", "test");
                await InvokeClientMethodOnlyAsync(id, "receiveMessage", "Server", $"You sent me this result: " + result);
            }
            catch (Exception ex)
            {
                await InvokeClientMethodOnlyAsync(id, "receiveMessage", "Server", $"I had an exception: " + ex.Message);
            }
        }

        private async Task Ask(WebSocket socket)
        {
            string id = WebSocketConnectionManager.GetId(socket);
            try
            {
                string result = await InvokeClientMethodAsync<string, string>(id, "IP", "test");
                await InvokeClientMethodOnlyAsync(id, "receiveMessage", "Server", $"You sent me this result: " + result);
            }
            catch (Exception ex)
            {
                await InvokeClientMethodOnlyAsync(id, "receiveMessage", "Server", $"I had an exception: " + ex.Message);
            }
        }


        public override async Task OnDisconnected(WebSocket socket)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);

            await base.OnDisconnected(socket);

            var message = new Message()
            {
                MessageType = MessageType.Text,
                Data = $"{socketId} disconnected"
            };
            await SendMessageToAllAsync(message);
        }

    }
}
