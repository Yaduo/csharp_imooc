using System;

namespace HelloWord
{
    internal class MailService : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("email: " + message);
        }
    }
}