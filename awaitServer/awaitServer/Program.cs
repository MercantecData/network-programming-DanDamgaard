using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Threading.Tasks;

namespace AsyncServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // declair simple varbles 
            bool done = false;
            string text = "";

            // declair connection
            int port = 13358;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();

            // openning text
            Console.WriteLine("Await Clients");

            // getting client and messages
            Task<TcpClient> asyncClient = acceptClient(listener);
            asyncClient.Wait();
            TcpClient client = asyncClient.Result;

            
            // instructions 
            Console.Write("Write your message or wait for a message from client \n");

            // send messages
            NetworkStream stream = client.GetStream();
            while (!done)
            {
                
                if (text != "done")
                { 
                    text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    
                    stream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    done = true;
                }
            }

            // close the program
            Console.WriteLine("Hit enter to close the server");
            
        }

        // add client and start getting messages
        public static async Task<TcpClient> acceptClient(TcpListener listener)
        {
            
            TcpClient client = await listener.AcceptTcpClientAsync();
            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);
            return client;
        }

        // get messages
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            bool done = false;
            while (!done)
            {
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                if (receivedMessage.Length > 0)
                {
                    Console.WriteLine("client message: " + receivedMessage);
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}
