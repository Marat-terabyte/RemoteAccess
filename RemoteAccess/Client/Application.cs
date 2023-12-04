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
        public ComputerInformationManager ComputerInfo;
        public ServerObject Server;
        public FileShareService FileShare;
        public CommandLineService CommandLine;

        public Application(ServerObject server, ComputerInformationManager computerInfoManager)
        {
            ComputerInfo = computerInfoManager;
            Server = server;
            FileShare = new FileShareService(server);
            CommandLine = new CommandLineService();
        }

        public void Run()
        {
            string infoAboutMachine = ComputerInfo.GetMainInformation();
            Server.SendToServer(infoAboutMachine);

            while (true)
            {
                string command = Server.ReceiveFromServer(4096);
            }
        }
    }
}
