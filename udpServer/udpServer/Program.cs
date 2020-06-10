using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // declair connection
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            UdpClient client = new UdpClient(endPoint);

            // start getting messages
            Receiver(client);

            // stop the program
            Console.ReadLine();
        }

        // get messages
        public static async void Receiver(UdpClient client)
        {
            while (true)
            {
                UdpReceiveResult result = await client.ReceiveAsync();
                byte[] buffer = result.Buffer;

                string text = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("client says: " + text);   
            }
            
        }
    }
}
