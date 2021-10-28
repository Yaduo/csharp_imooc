namespace CMS
{
    public interface IUser
    {
        bool IsUserLogin { get; set; }

        void Login();
    }
}