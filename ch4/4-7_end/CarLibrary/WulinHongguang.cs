using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class WulinHongguang : Car
    {
        public void Drift()
        {
            this.Accelerate();
            this.Stop();
        }
    }
}
