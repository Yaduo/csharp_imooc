using System;

namespace SSD
{
    public class SSD : Computer.SDK.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("1TB 固态硬盘");
        }

        public void Read()
        {
            Console.WriteLine("读取固态硬盘数据");
        }

        public void Wirte()
        {
            Console.WriteLine("写入固态硬盘数据");
        }
    }
}
