using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello World";
            Console.WriteLine(hello.ShortTerm(2)); // He

            IEnumerable list = new List<int>();
            //list.

            Console.Read();
        }
    }

    public static class StringExtension
    {
        public static string ShortTerm(this string str, int num)
        {
            return str.Substring(0, num);
        }
    }

    //class RichString: String
    //{

    //}

}
