using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace awaitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // declair simple varibles
            bool done = false;
            string text = "";

            // declair connection 
            TcpClient client = new TcpClient();
            int port = 13358;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);
   
            // start connection
            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();
            
            //openning text
            Console.Write("Write your message or wait for a message from server \n");

            // start getting messages
            RecieveMessage(stream, client);

            // send messeges or stop program
            while (!done)
            {
                if (text != "done")
                {
                    text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);

                        if (client.Connected)
                        {
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        else
                        {
                            done = true;
                        }
                }
                else
                {
                    done = true;
                }
            }

            // end the program 
            Console.WriteLine("client will close down now");
            client.Close();
        }

        // get messages or end the program
        public static async void  RecieveMessage(NetworkStream stream, TcpClient client)
        {
            byte[] buffer = new byte[256];
            bool done = false;
            String receivedMessage = "";
            while (!done)
            {
                
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                if (receivedMessage != "end" && receivedMessage.Length > 0)
                {
                    Console.WriteLine("Server message: " + receivedMessage);
                }
                else
                {
                    Console.WriteLine("Server message: " + receivedMessage);
                    stream.Close();
                    client.Close();
                    done = true;
                    Console.WriteLine("Hit enter to close the client");
                }
            }
        } 
    }
}
