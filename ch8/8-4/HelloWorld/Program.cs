using System;
using System.Timers;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;

            Console.Read();
        }
    }
}
