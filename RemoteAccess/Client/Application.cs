using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [SupportedOSPlatform("windows")]
    internal class Application
    {
        private ComputerInformationManager _computerInfoManager;

        public ClientSocket ClientSocket {  get; private set; }

        public Application(ClientSocket clientSocket, ComputerInformationManager computerInfoManager)
        {
            _computerInfoManager = computerInfoManager;
            ClientSocket = clientSocket;
        }

        public void Run()
        {
            string infoAboutMachine = _computerInfoManager.GetMainInformation();
            ClientSocket.SendToServer(infoAboutMachine);
        }
    }
}
