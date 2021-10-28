using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        // 主方法
        static void Main(string[] args)
        {
            // 2d 坐标点：{x: 15, y: 10}
            //dynamic var
            Point a = new Point(15, 10);
            a.DrawPoint();

            Point b = new Point(22, 10);
            double result = a.GetDistances(b);
            Console.WriteLine(result);

            // public, private, protected, internal
            Point point = new Point(25, 50);
            point.X = 30;
            //point.T = 14;
            //Console.WriteLine(point.S);
            //point.SetX(-30);
            Console.WriteLine(point.X);
            point.X = 15;
            //point.a = 40;

            point[0] = "hello";
            Console.WriteLine(point[0]); // "The"

            Console.WriteLine(point["brown"]); // 2

            point.D = 1;
            point.printDelta();

            Console.Read();
            return;
        }
    }
}
