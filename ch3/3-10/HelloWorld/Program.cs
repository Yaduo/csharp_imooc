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
            // 时间维度，readonly
            public int T { get; }
            // 黑洞奇点，wirteonly
            private int _s;
            public int S { set { _s = value; } }
            // 第六维，常量
            public const int a = 99;
            // 第七维，readonly 变量
            public readonly int b;

            public Point()
            {
                this._x = 15;
                y = 10;
                T = 20;
                //a = 40;
                b = 1000;
            }

            public Point(int x, int y)
            {
                this._x = x;
                this.y = y;
                b = 99;
            }

            public Point(int x)
            {
                this._x = x;
                this.y = 10;
            }

            public void DrawPoint()
            {
                Console.WriteLine($"左边点为 x: {_x},  y: {y}");
            }


            public double GetDistances(Point p) =>
                Math.Pow(_x - p.X, 2) + Math.Pow(y - p.y, 2);
        }
    }
}
