using System;
using System.Text;

namespace byteToString
{
    class Program
    {
        static void Main(string[] args)
        {
            // message to convert to byte
            string str = "halløj med dig";

            // convert message to bytes
            byte[] myBytes = Encoding.UTF8.GetBytes(str);

            // convert bytes to text and print it
            string byteStr = Encoding.UTF8.GetString(myBytes);
            Console.WriteLine(byteStr);
        }
    }
}
