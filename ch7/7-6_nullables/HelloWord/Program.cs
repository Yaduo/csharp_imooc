using System;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime date = null;
            //Nullable<DateTime> date = null;
            //DateTime? date = null;

            //Console.WriteLine(date.GetValueOrDefault());
            //Console.WriteLine(date.HasValue);
            //Console.WriteLine(date.Value);

            DateTime? date = new DateTime(2099, 1, 1);
            DateTime date2 = date.GetValueOrDefault();
            DateTime? date3 = date2;

            if(date3 != null)
            {
                Console.WriteLine(date3.GetValueOrDefault());
            } else
            {
                Console.WriteLine(DateTime.Today);
            }

            var result = date3 ?? DateTime.Today;
            Console.WriteLine(result);

            Console.Read();
        }
    }
}
