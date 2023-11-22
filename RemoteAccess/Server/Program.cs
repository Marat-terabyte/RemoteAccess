namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server socketServer = new Server();
            socketServer.CreateServer(Settings.Host, Settings.Port);

            ClientManager socketClient = new ClientManager(socketServer);
            socketClient.GetConnection();

            Application app = new Application(socketClient);
            app.Run();
        }
    }
}
