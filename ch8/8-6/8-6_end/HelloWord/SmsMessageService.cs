using System;
namespace HelloWord
{
    public class SmsMessageService
    {
        internal static void OnOrderProcessed(Order order, OrderProcessorEventArgs args)
        {
            Console.WriteLine($"发送短信，订单 {order.Id} , 处理结果: {args.Status}, 处理时间: {args.ProcessingTime}");
        }
    }
}
