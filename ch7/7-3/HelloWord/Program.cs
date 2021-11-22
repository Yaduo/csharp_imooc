using System;

namespace HelloWord
{
    class Program
    {
        enum Weekday
        {
            MONDAY = 1,
            TUESDAY,
            WEDNESDAY,
            THURSDAY,
            FRIDAY = 5,
            SATURDAY,
            SUNDAY
        }

        static void Main(string[] args)
        {
            Weekday firday = Weekday.FRIDAY;

            Console.WriteLine(firday);
            Console.WriteLine((int)firday);

            var firday2 = (Weekday)4;
            Console.WriteLine(firday2);

            Weekday day = Weekday.MONDAY;

            switch(day)
            {
                case Weekday.MONDAY:
                case Weekday.TUESDAY:
                case Weekday.WEDNESDAY:
                case Weekday.THURSDAY:
                case Weekday.FRIDAY:
                    Console.WriteLine("今天要上班");
                    break;
                case Weekday.SUNDAY:
                case Weekday.SATURDAY:
                    Console.WriteLine("家里蹲");
                    break;
            }

            Console.Read();
        }
    }
}
