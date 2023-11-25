using System.Runtime.Versioning;

namespace Client
{
    internal class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            ComputerInformationManager computerInfoManager = new ComputerInformationManager();

            ClientSocket clientSocket = new ClientSocket();
            clientSocket.ConnectToServer(Settings.Host, Settings.Port);

            Application app = new Application(clientSocket, computerInfoManager);
            app.Run();
        }
    }
}
