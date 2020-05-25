using System;
using System.Text;

namespace byteToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "halløj med dig";

            byte[] myBytes = Encoding.UTF8.GetBytes(str);

            string byteStr = Encoding.UTF8.GetString(myBytes);
            Console.WriteLine(byteStr);
        }
    }
}
