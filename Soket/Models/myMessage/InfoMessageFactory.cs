using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketManager.Common;

namespace Soket.Models.myMessage
{
    public class InfoMessageFactory
    {
        const string server = "Server";
        const string client = "Client";
        const string infoType = "Info";
        const string socketID = "SocketID";
        const string socketIp = "ClientIp";
        public static Message GetSocketId(string id)
        {
            InfoMessage infoMessage = new InfoMessage
            {
                // base info
                Sender = server,
                Recipient = client,
                Type = infoType,
                UtcTime = DateTime.UtcNow,
                ServerTime = DateTime.Now,

                // custom info
                SubType = socketID,
                Data = id
            };

            /* Nurget Newtonsoft.Json */
            var json = JsonConvert.SerializeObject(infoMessage);

            /* Message Object */
            var message = new Message()
            {
                MessageType = MessageType.Text,
                Data = $"{json}"
            };

            return message;
        }



        public static string GetClientIp(string ip)
        {
            InfoMessage infoMessage = new InfoMessage
            {
                // base info
                Sender = server,
                Recipient = client,
                Type = infoType,
                UtcTime = DateTime.UtcNow,
                ServerTime = DateTime.Now,

                // custom info
                SubType = socketIp,
                Data = ip
            };

            /* Nurget Newtonsoft.Json */
            var json = JsonConvert.SerializeObject(infoMessage);

            

            return json;
        }

    }

    


}
