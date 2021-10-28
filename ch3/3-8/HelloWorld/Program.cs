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
            //point.SetX(-30);
            Console.WriteLine(point.X);

            Console.Read();
            return;
        }

        public class Point
        {
            // 成员变量x轴，使用属性
            private int _x;
            public int X
            {
                get { return this._x; }
                set
                {
                    if (value < 0)
                    {
                        throw new Exception("value不能小于0");
                    }
                    this._x = value;
                }
            }
            // 成员变量y轴，使用setY getY方法
            private int y;
            public void SetY(int value)
            {
                if (value < 0)
                {
                    throw new Exception("value不能小于0");
                }
                this.y = value;
            }
            public int GetY() => this.y;
            // 成员变量z轴，自动生成getter、setter
            public int Z { get; set; }

            public Point()
            {
                this._x = 15;
                y = 10;
            }

            public Point(int x, int y)
            {
                this._x = x;
                this.y = y;
            }

            public Point(int x)
            {
                this._x = x;
                this.y = 10;
            }

            public void DrawPoint() =>
                Console.WriteLine($"左边点为 x: {_x},  y: {y}");

            public double GetDistances(Point p) =>
                Math.Pow(_x - p.X, 2) + Math.Pow(y - p.y, 2);
        }
    }
}
