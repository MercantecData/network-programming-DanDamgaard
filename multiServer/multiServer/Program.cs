using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace multiServer
{
    class Program
    {
        public static List<TcpClient> clients = new List<TcpClient>();

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Any;
            int port = 13356;
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            
            AcceptClients(listener);

            Console.WriteLine("Write to client or wait for a message");
            bool isRunning = true;
            while (isRunning)
            {
                
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                
                foreach(TcpClient client in clients)
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
            }

        }

        public static async void AcceptClients(TcpListener listener)
        {
            
            bool isRunning = true;
            while (isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream, client);
            }
        }

        public static async void ReceiveMessage(NetworkStream stream, TcpClient client)
        {
            byte[] buffer = new byte[256];
            bool isRunning = true;
            while (isRunning)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                string text = Encoding.UTF8.GetString(buffer, 0, read);
                if(text.Length > 0)
                {
                    Console.WriteLine("Client writes: " + text);
                    
                }
                else if (text.Length == 0)
                {
                    client.Close();
                    
                    clients.Remove(client);
                    isRunning = false;
                }
            }
                
        }
    }
}
