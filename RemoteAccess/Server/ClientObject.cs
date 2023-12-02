using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class ClientObject
    {
        public Socket Client { get; private set; }

        private NetworkStream _stream;
        
        public ClientObject(Socket client)
        {
            Client = client;
            _stream = new NetworkStream(client);
        }

        public void SendToClient(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);

            Client.Send(data);
        }

        public string ReceiveFromClient(int size)
        {
            byte[] byteResponse = new byte[size];

            var bytes = Client.Receive(byteResponse);
            string response = Encoding.UTF8.GetString(byteResponse, 0, bytes);

            return response;
        }
    }
}
