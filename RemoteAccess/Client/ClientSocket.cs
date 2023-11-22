using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ClientSocket
    {
        public Socket Client {  get; private set; }

        public ClientSocket()
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

        }

        public void ReceiveFromServer()
        {
            
        }
    }
}
