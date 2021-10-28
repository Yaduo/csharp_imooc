using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeList = new List<Shape>();
            shapeList.Add(new Shape()
            {
                ShapeType = ShapeType.Circle
            });
            shapeList.Add(new Shape()
            {
                ShapeType = ShapeType.Rectangle
            });

            var canvas = new Canvas();
            canvas.DrawShapes(shapeList);

            Console.Read();
        }
    }
}
