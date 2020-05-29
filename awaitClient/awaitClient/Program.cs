﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace awaitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);
            

            NetworkStream stream = client.GetStream();
            RecieveMessage(stream);

            Console.Write("Write your message here: ");
            string text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);
            
            client.Close();
            Console.ReadKey();
        }

        public static async void RecieveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("\n" + receivedMessage);
        }
    }
}
