using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public partial class Point
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
        // 第八维，字符串数组
        private string[] _g = new string[]
        {
                // index from start index from end
	             "The",  // 0     ^9
	             "quick", // 1     ^8
	             "brown", // 2     ^7
	             "fox",  // 3     ^6
	             "jumped", // 4     ^5
	             "over",  // 5     ^4
	             "the",  // 6     ^3
	             "lazy",  // 7     ^2
	             "dog"  // 8     ^1
        };    // 9 (or words.Length) ^0

        public string this[int index]
        {
            get
            {
                return _g[index];
            }
            set
            {
                _g[index] = value;
            }
        }

        public int this[string name]
        {
            get
            {
                return Array.IndexOf(_g, name);
            }
        }

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
