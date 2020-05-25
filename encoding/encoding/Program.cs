using System;
using System.Text;

namespace encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "halløj med dig";

            byte[] byteStr = Encoding.ASCII.GetBytes(str);

            foreach(byte b in byteStr)
            {
                Console.WriteLine(b);
            }
        }
    }
}
