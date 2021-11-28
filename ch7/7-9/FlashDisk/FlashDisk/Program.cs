using System;

namespace FlashDisk
{
    class Program
    {
        static void Main(string[] args)
        {
            FlashDisk fd = new FlashDisk();
            fd.GetInfo();
            fd.Read();
            fd.Wirte();

            Console.Read();
        }
    }
}
