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
                TotalPrice = 30f
            };

            // 双十一
            IShippingCalculator doubleEleven = new DoubleElevenShippingCalculator();
            // 普通
            IShippingCalculator putong = new ShippingCalculator();

            OrderProcessor orderProcessor;
            if (DateTime.Now == new DateTime(2050, 11, 11))
            {
                orderProcessor = new OrderProcessor(doubleEleven);
            }
            else
            {
                orderProcessor = new OrderProcessor(putong);
            }
            orderProcessor.Process(order);

            Console.Read();
        }
    }
}
