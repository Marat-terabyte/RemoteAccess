namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server socketServer = new Server();
            socketServer.CreateServer(Settings.Host, Settings.Port);

            ClientManager socketClient = socketServer.GetConnection();
            Console.WriteLine(socketClient.Client.RemoteEndPoint?.ToString());
            Application app = new Application(socketClient);
            app.Run();
        }
    }
}
