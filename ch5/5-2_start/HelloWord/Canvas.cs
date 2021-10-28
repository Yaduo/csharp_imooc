using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape.ShapeType)
                {
                    case ShapeType.Circle:
                        Console.WriteLine("画圆");
                        break;
                    case ShapeType.Rectangle:
                        Console.WriteLine("画方");
                        break;
                }
            }
        }
    }
}
