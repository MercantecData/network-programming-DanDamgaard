using System;
using System.Text;

namespace encodingUTF
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "halløj med dig";

            byte[] myBytes = Encoding.UTF8.GetBytes(str);

            foreach(byte b in myBytes)
            {
                Console.WriteLine(b);
            }

        }
    }
}
