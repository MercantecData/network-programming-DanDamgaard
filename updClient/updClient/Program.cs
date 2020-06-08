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
            UdpClient client = new UdpClient();

            string text = "hello UPD"; 
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            client.Send(bytes, bytes.Length, endPoint);
        }

    }
}
