using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var photo = Photo.load("photo.jpg");

            var processor = new PhotoProcessor();

            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RemoveRedEyesFilter;

            processor.Process(photo, filterHandler);

            Console.Read();
        }

        static void RemoveRedEyesFilter(Photo photo)
        {
            Console.WriteLine("去除红眼");
        }
    }
}
