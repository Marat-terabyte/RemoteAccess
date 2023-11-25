using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Application
    {
        public ClientManager ClientManager;

        public Application(ClientManager clientManager)
        {
            ClientManager = clientManager;
        }

        public void Run()
        {
            string response = ClientManager.ReceiveFromClient(4096);
            Console.WriteLine(response);    
        }
    }
}
