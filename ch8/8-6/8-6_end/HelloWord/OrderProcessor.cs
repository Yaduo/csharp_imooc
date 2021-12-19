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

    public delegate void OrderProcessorEventHandler(Order order, OrderProcessorEventArgs args);

    public class OrderProcessor
    {
        private OrderProcessorEventHandler _orderProcessorEventHandler;

        public event OrderProcessorEventHandler OrderProcessorEvent
        {
            add
            {
                this._orderProcessorEventHandler += value;
            }
            remove
            {
                this._orderProcessorEventHandler -= value;
            }
        }

        public void Process(Order order)
        {
            // 订单处理...

            // 订单处理完成，发送订单处理完成事件
            if (_orderProcessorEventHandler != null)
            {
                var e = new OrderProcessorEventArgs
                {
                    Status = "completed",
                    ProcessingTime = DateTime.UtcNow,
                    Desctiption = "处理得非常成功"
                };
                _orderProcessorEventHandler(order, e);
            }
        }
    }
}
