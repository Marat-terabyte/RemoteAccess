using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        public Socket Socket { get; private set; }

        public Server()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void CreateServer(string host, int port)
        {
            Socket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
            Socket.Listen(1);
        }

        public ClientManager GetConnection()
        {
            Socket client = Socket.Accept();

            return new ClientManager(client);
        }
    }
}
