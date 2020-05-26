using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13356;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();

            Console.WriteLine("Awaiting Clients");
            TcpClient client = listener.AcceptTcpClient();

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[256];
            int numberOfBytesRead = stream.Read(buffer, 0, 256);

            string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
            Console.WriteLine(message);

        }
    }
}
