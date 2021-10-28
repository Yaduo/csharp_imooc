using System;

namespace HelloWord
{
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine($"日志 {DateTime.Now}: {message}");
        }
    }
}
