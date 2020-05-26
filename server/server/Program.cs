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
            // Declare
            int port = 13356;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            // Start listen for Client
            TcpClient client = startConnect(localEndpoint);

            // Message from client
            Console.WriteLine(myMessage(client));

        }

        public static TcpClient startConnect(IPEndPoint localEndpoint)
        {
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();
            Console.WriteLine("Awaiting Clients");
            TcpClient client = listener.AcceptTcpClient();

            return client;
        }

        public static string myMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[256];
            int numberOfBytesRead = stream.Read(buffer, 0, 256);
            string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
            return message;

        }
    }
}
