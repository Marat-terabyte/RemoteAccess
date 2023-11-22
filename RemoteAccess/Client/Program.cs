namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientSocket clientSocket = new ClientSocket();
            clientSocket.ConnectToServer(Settings.Host, Settings.Port);

            Application app = new Application(clientSocket);
            app.Run();
        }
    }
}
