using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWord
{
    class Program
    {
        public class Shape
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public void Draw()
            {
                Console.WriteLine($"Width: {Width}, Height: {Height}, position: ({X}, {Y})");
            }
        }

        public class Text : Shape
        {
            public int FontSize { get; set; }
            public string FontName { get; set; }
        }

        static void Main(string[] args)
        {
            var text = new Text();
            Shape shape = text;

            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            //cars[0] = 1;

            var arrays = new ArrayList();
            arrays.Add(1);
            arrays.Add("123");
            arrays.Add(text);
            arrays.Add(new Shape());
            arrays.Add(cars);

            var shapeList = new List<Shape>();
            shapeList.Add(text);
            shapeList.Add(new Shape());

            // 向下引用 
            var shape0 = shapeList[0];
            var textList = new List<Text>();
            shapeList.ForEach(s =>
            {
                if (s is Text)
                {
                    textList.Add((Text)s);
                }
            });



            Console.Read();
        }
    }
}
