using System;

namespace FlashDisk
{
    public class FlashDisk : Computer.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("32G U盘");
        }

        public void Read()
        {
            Console.WriteLine("读取U盘数据");
        }

        public void Wirte()
        {
            Console.WriteLine("写入U盘数据");
        }
    }
}
