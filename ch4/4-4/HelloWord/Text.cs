using System;

namespace HelloWord
{
    public class Text: PresentationObject
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }

        public void AddHyperLink()
        {
            Console.WriteLine("添加超链接");
        } 
    }
}
