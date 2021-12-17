namespace HelloWorld
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(Photo photo, PhotoFilterHandler filterHandler)
        {
            filterHandler(photo);
            photo.Save();
        }
    }
}
