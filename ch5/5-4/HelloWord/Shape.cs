using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画圆");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画方");
        }
    }

    public class Trangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画三角");
        }
    }

    public class Oval : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画椭圆");
        }
    }

    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }

        public abstract void Draw();

        public void Copy()
        {
            Console.WriteLine("复制");
        }

        public void Paste()
        {
            Console.WriteLine("粘贴");
        }
    }
}
