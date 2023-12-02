using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class FileShareService
    {
        private readonly ClientObject _client;

        public FileShareService(ClientObject client)
        {
            _client = client;
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

            _client.SendToClient(cycles.ToString());

            byte[] buffer = new byte[sizeToSend];
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                for (long i = 0; i < cycles; i++)
                {
                    fs.Read(buffer, 0, sizeToSend);
                    _client.Client.Send(buffer);
                }
            }
        }

        public void ReceiveFile(string filename)
        {
            byte[] buffer = new byte[4096];
            long cycles = long.Parse(_client.ReceiveFromClient(20));
            Console.WriteLine(cycles);
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                for (long i = 0; i < cycles; i++)
                {
                    int bytes = _client.Client.Receive(buffer);
                    fs.Write(buffer, 0, bytes);
                }
            }
        }
    }
}
