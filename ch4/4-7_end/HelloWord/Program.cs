using System;
using CarLibrary;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            var wulin = new WulinHongguang();
            wulin.Accelerate();
            wulin.Drift();

            Console.Read();
        }
    }
}
