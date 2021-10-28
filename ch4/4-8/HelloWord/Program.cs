using System;

namespace HelloWord
{
    class Program
    {
        public class Staff
        {
            public Staff()
            {
                Console.WriteLine("员工类初始化");
            }

            public int Number { get; set; }
            public Staff(int number)
            {
                Number = number;
            }
        }

        public class Manager : Staff
        {
            public Manager()
            {
                Console.WriteLine("经理类初始化");
            }
            public Manager(int number)
            {
            }
        }

        static void Main(string[] args)
        {
            var manager = new Manager(123);
            Console.WriteLine(manager.Number);

            Console.Read();
        }
    }
}
