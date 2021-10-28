using System;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWord
{

    class Program
    {
        static void Main(string[] args)
        {
            // 创建订单
            var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 30f
            };

            //配置 IOC 反转控制容器
            var collection = new ServiceCollection();
            collection.AddScoped<IShippingCalculator, DoubleElevenShippingCalculator>();
            collection.AddScoped<IOrderProcessor, OrderProcessor>();
            //collection.AddSingleton<IOrderProcessor, OrderProcessor>();
            //collection.AddTransient<IOrderProcessor, OrderProcessor>();
            IServiceProvider serviceProvider = collection.BuildServiceProvider();

            // 通过接口，从IOC中找出订单处理器
            var orderProcessor = serviceProvider.GetService<IOrderProcessor>();
            //var orderProcessor2 = serviceProvider.GetService<IOrderProcessor>();

            // 处理订单
            orderProcessor.Process(order);

            Console.Read();
        }
    }
}
