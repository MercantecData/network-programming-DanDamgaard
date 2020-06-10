using System;
using System.Text;

namespace encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // message to convert to bytes
            string str = "halløj med dig";

            // convert message to bytes
            byte[] byteStr = Encoding.ASCII.GetBytes(str);

            // print out bytes
            foreach(byte b in byteStr)
            {
                Console.WriteLine(b);
            }
        }
    }
}
