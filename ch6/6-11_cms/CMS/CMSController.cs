namespace CMS
{
    partial class Program
    {
        public class CMSController : ICMSController
        {
            private readonly IUser _user;
            private readonly IMenu _menu;
            public CMSController(IUser user, IMenu menu)
            {
                _menu = menu;
                _user = user;
            }

            public void Start()
            {
                // login
                do
                {
                    _user.Login();
                } while (!_user.IsUserLogin);

                // start Menu
                _menu.ShowMenu();
            }

        }
    }
}
