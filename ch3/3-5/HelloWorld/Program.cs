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
            Point a = new Point();
            a.x = 15;
            a.y = 10;
            a.DrawPoint();

            Point b = new Point();
            b.x = 22;
            b.y = 10;
            double result = a.GetDistances(b);
            Console.WriteLine(result);

            Console.Read();
            return;
        }

        public class Point
        {
            public int x;
            public int y;

            public void DrawPoint() =>
                Console.WriteLine($"左边点为 x: {x},  y: {y}");

            public double GetDistances(Point p) =>
                Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2);
        }
    }
}
