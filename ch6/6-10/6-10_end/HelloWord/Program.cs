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

            // 注册第一种消息通道
            //INotification email = new MailService();
            MailService email = new MailService();
            orderProcessor.RegisterNotification(email);

            // 注册第二种消息通道
            INotification sms = new SmsMessageService();
            orderProcessor.RegisterNotification(sms);
            

            orderProcessor.Process(order);
           

            Console.Read();
        }
    }
}
