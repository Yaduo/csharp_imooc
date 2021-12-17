using System;

namespace HelloWorld
{
    public class PhotoProcessor
    {

        public void Process(Photo photo, Action<Photo> filterHandler)
        {
            filterHandler(photo);
            photo.Save();
        }
    }
}
