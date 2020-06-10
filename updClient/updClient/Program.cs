using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace updClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // declair connection
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            //opening text
            Console.WriteLine("Write a message");

            // send messages
            while (true)
            {
                string text = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(text);

                client.Send(bytes, bytes.Length, endPoint);
            }
        }

    }
}
