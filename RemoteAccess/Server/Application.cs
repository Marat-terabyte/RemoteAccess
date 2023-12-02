using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Application
    {
        public ClientObject ClientManager;
        public FileShareService FileShare;

        public Application(ClientObject clientManager)
        {
            ClientManager = clientManager;
            FileShare = new FileShareService(clientManager);
        }

        public void Run()
        {
            string infoAboutComputer = ClientManager.ReceiveFromClient(4096);
            Console.WriteLine(infoAboutComputer);

            while (true)
            {
                Console.Write(">>>");
                string command = Console.ReadLine()!;
                
                ClientManager.SendToClient(command);
            }
        }
    }
}
