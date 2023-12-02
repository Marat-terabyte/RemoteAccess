using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class FileShareService
    {
        private readonly ServerObject _server;

        public FileShareService(ServerObject server)
        {
            _server = server;
        }

        public void SendFile(string path)
        {
            if (!new FileInfo(path).Exists)
            {
                Console.WriteLine("File does not exist!");
                return;
            }

            int sizeToSend = 4096;
            long fileSize = new FileInfo(path).Length;
            long cycles = (fileSize + sizeToSend + 1) / sizeToSend;
            Console.WriteLine(fileSize);
            _server.SendToServer(cycles.ToString());
            Console.WriteLine(cycles);

            byte[] buffer = new byte[sizeToSend];
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                for (long i = 0; i < cycles; i++)
                {
                    fs.Read(buffer, 0, sizeToSend);
                    _server.Client.Send(buffer);
                }
            }
        }

        public void ReceiveFile(string filename)
        {
            byte[] buffer = new byte[4096];
            long cycles = long.Parse(_server.ReceiveFromServer(20));
            
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                for (long i = 0; i < cycles; i++)
                {
                    int bytes = _server.Client.Receive(buffer);
                    fs.Write(buffer, 0, bytes);
                }    
            }
        }
    }
}
