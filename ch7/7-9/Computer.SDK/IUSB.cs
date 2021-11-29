using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.SDK
{
    public interface IUSB
    {
        void GetInfo();
        void Read();
        void Wirte();
    }
}
