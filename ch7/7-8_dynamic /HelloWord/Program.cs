using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWord
{
    public class Excel
    {
        public string Table { get; set; }
        public void ShowTable()
        {
            Console.WriteLine("打印excel表格");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //object obj = new Excel();
            //var obj = new Excel();
            dynamic obj = new Excel();
            obj.GetHashCode();
            obj.ShowTable();

            //var methodInfo = obj.GetType().GetMethod("ShowTable");
            //methodInfo.Invoke(null, null);

            obj = "hello world";

            Console.Read();
        }
    }
}
