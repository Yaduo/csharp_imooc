using System;
namespace HelloWord
{
    public class OrderProcessor
    {
        private readonly MailService _mailService;

        public OrderProcessor()
        {
            _mailService = new MailService();
        }

        public void Process(Order order)
        {
            // 处理订单...处理发货...

            // 通知用户收货
            _mailService.Send("订单已发货");
        }
    }
}
