using System;
using System.Collections.Generic;

namespace HelloWord
{
    public class OrderProcessorEventArgs : EventArgs
    {
        public string Status { get; set; }
        public DateTime ProcessingTime { get; set; }
        public string Desctiption { get; set; }
    }

    public class OrderProcessor
    {

        public event EventHandler<OrderProcessorEventArgs> OrderProcessorEvent;

        public void Process(Order order)
        {
            // 订单处理...

            // 订单处理完成，发送订单处理完成事件
            if (OrderProcessorEvent != null)
            {
                var e = new OrderProcessorEventArgs
                {
                    Status = "completed",
                    ProcessingTime = DateTime.UtcNow,
                    Desctiption = "处理得非常成功"
                };
                OrderProcessorEvent(order, e);
            }
        }
    }
}
