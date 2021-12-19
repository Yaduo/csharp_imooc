using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void RedEyesRemovalFilter(Photo photo)
        {
            Console.WriteLine("去除红颜");
        }

        static void Main(string[] args)
        {
            var photo = Photo.load("phtot.jpg");

            var filters = new PhotoFilters();

            PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RedEyesRemovalFilter;

            var processor = new PhotoProcessor();
            processor.Process(photo, filterHandler);

            Console.Read();
        }
    }
}
