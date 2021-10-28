using System;
using System.Collections;
using System.Collections.Generic;

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
                TotalPrice = 30f
            };

            OrderProcessor orderProcessor = new OrderProcessor();
            orderProcessor.Process(order);
            
            Console.Read();
        }
    }
}
