using System;

namespace CMS
{
    partial class Program
    {
        public class User : IUser
        {
            public bool IsUserLogin { get; set; }

            public void Login()
            {
                string username;
                string password;

                username = CmdReader("用户名: ");
                if (username != "alex")
                {
                    Console.WriteLine("查无此人");
                    return;
                }

                password = CmdReader("密码: ");
                if (password != "123456")
                {
                    Console.WriteLine("密码错误， 请重试。");
                    return;
                }

                IsUserLogin = true;
            }
        }
    }
}
