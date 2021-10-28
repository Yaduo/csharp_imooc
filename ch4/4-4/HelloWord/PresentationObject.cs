using System;

namespace HelloWord
{
    public class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

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
