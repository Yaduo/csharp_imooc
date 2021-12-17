using System;
using System.Collections.Generic;

namespace HelloWord
{
    public class OrderProcessor
    {
        private readonly List<INotification> _notificationServices;

        public OrderProcessor()
        {
            _notificationServices = new List<INotification>();
        }

        public void RegisterNotification(INotification notification)
        {
            _notificationServices.Add(notification);
        }

        public void Process(Order order)
        {
            // 处理订单...处理发货...

            // 通知用户收货
            foreach (INotification n in _notificationServices)
            {
                n.Send("订单已发货");
            }
        }
    }
}
