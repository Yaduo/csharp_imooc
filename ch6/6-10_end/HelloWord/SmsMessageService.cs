using System;
namespace HelloWord
{
    public class SmsMessageService : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("短信: " + message);
        }
    }
}
