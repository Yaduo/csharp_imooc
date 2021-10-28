using System;

namespace HelloWord
{
    partial class Program
    {
        public class Car
        {
            public void Accelerate()
            {
                Console.WriteLine("加油");
            }

            protected void Stop()
            {
                Console.WriteLine("制动");
            }
        }
    }
}
