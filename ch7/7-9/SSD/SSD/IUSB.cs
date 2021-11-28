using System;
namespace SSD
{
    public interface IUSB
    {
        void GetInfo();
        void Read();
        void Wirte();
    }
}
