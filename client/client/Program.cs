using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declar
            TcpClient client = new TcpClient();
            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            // Concect with target
            NetworkStream stream = myStream(client, endPoint);

            // Message
            byte[] buffer = message();

            // Send message
            stream.Write(buffer, 0, buffer.Length);
            client.Close();



        }


        public static NetworkStream myStream(TcpClient client, IPEndPoint endPoint)
        {
            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();
            return stream;
        }

        public static byte[] message()
        {
            string text = "Come to the darkside we have cookies";
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            return buffer;
        }
    }
}
