using System;

namespace HelloWord
{

    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f
            };

            var orderProcessor = new OrderProcessor();

            orderProcessor.Process(order);

            Console.Read();
        }
    }
}
