using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Application
    {
        public ClientSocket ClientSocket {  get; private set; }

        public Application(ClientSocket clientSocket)
        {
            ClientSocket = clientSocket;
        }

        public void Run()
        {

        }
    }
}
