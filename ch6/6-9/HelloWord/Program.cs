using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWord
{
    public class UIText : UIBase, IDragable, ICopyable
    {
        public void Copy()
        {
            Console.WriteLine("复制");
        }

        public void Drag()
        {
            Console.WriteLine("拖拽");
        }
    }

    internal interface ICopyable
    {
        public void Copy();
    }

    internal interface IDragable
    {
        public void Drag();
    }

    public class UIBase
    {
        public int Size { get; set; }
        public Position Position { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("这里是图案绘制逻辑");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
        }
    }
}
