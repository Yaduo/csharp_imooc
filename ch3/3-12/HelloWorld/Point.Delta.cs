using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public partial class Point
    {
        //第九维 delta
        public int D { get; set; }

        public void printDelta()
        {
            Console.WriteLine("我是第九维");
        }
    }
}
