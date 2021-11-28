using System;

namespace SSD
{
    class Program
    {
        static void Main(string[] args)
        {
            SSD ssd = new SSD();
            ssd.GetInfo();
            ssd.Read();
            ssd.Wirte();

            Console.Read();
        }
    }
}
