using System;
using System.Timers;

namespace HelloWorld
{
    public class Alex
    {
        internal void AlarmEventHandler(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("闹钟响了, 我不管");
        }
    }

    public class RoomMate
    {
        public int RageValue { get; set; }

        internal void AlarmEventHandler(object sender, ElapsedEventArgs e)
        {
            RageValue += 25;
            if(RageValue >= 100)
            {
                Console.WriteLine("受不了了");
                ((Timer)sender).Stop();
            }
            Console.WriteLine("闹钟响了, 我也不管");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;

            var alex = new Alex();
            var roomMate = new RoomMate();
            timer.Elapsed += alex.AlarmEventHandler;
            timer.Elapsed += roomMate.AlarmEventHandler;

            timer.Start();

            Console.Read();
        }
    }
}
