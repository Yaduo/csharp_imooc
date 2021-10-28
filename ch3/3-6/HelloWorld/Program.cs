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

            Console.Read();
            return;
        }

        public class Point
        {
            public int x;
            public int y;

            public Point()
            {
                this.x = 15;
                y = 10;
            }

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Point(int x)
            {
                this.x = x;
                this.y = 10;
            }

            public void DrawPoint() =>
                Console.WriteLine($"左边点为 x: {x},  y: {y}");

            public double GetDistances(Point p) =>
                Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2);
        }
    }
}
