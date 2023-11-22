using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class ClientManager
    {
        private Server _server;

        public Socket Client { get; private set; }

        public ClientManager(Server server)
        {
            _server = server;
        }

        public void GetConnection()
        {
            Client = _server.Socket.Accept();
        }

        public void SendToClient()
        {

        }

        public void ReceiveFromServer()
        {

        }
    }
}
