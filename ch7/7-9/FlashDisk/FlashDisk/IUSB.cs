using System;
namespace FlashDisk
{
    public interface IUSB
    {
        void GetInfo();
        void Read();
        void Wirte();
    }
}
