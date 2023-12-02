using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ServerObject
    {
        private NetworkStream _stream;
        
        public Socket Client {  get; private set; }

        public ServerObject()
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void ConnectToServer(string host, int port)
        {
            bool connected = false;

            while (!connected)
            {
                try
                {
                    Client.Connect(new IPEndPoint(IPAddress.Parse(host), port));
                    _stream = new NetworkStream(Client);

                    return;
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void DisconnectFromServer()
        {
            Client.Disconnect(true);
        }

        public void SendToServer(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);

            Client.Send(data);
        }

        public string ReceiveFromServer(int size)
        {
            byte[] byteResponse = new byte[size];

            var bytes = Client.Receive(byteResponse);
            string response = Encoding.UTF8.GetString(byteResponse, 0, bytes);

            return response;
        }
    }
}
