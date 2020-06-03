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
            TcpClient client = new TcpClient();

            int port = 13357;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            string text = "";


            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();
            

            Console.Write("Write your message or wait for a message from server \n");



            Task test = RecieveMessage(stream, client);
            Task sendt = sendMessage(stream);
            Task[] tasks = { test, sendt};
            Task.WhenAny(tasks);



            Console.WriteLine("client will close down now");
            client.Close();
        }

        public static async Task RecieveMessage(NetworkStream stream, TcpClient client)
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
                    client.Close();
                    done = true;
                }
            }
        }

            public static async Task sendMessage(NetworkStream stream)
            {
            String text = "";
            bool done = false;

            while ( !done)
            {
                if (text != "done")
                {

                    Console.Write("Client says: ");
                    text = Console.ReadLine();

                    byte[] buffer = Encoding.UTF8.GetBytes(text);


                    await stream.WriteAsync(buffer, 0, buffer.Length);

                }
                else
                {
                    done = true;
                }

            }
        }

    }
}
