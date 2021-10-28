using System;

namespace CMS
{
    class Program
    {
        public static string CmdReader(string instruction)
        {
            Console.Write(instruction);
            string cmd = Console.ReadLine();
            return cmd;
        }

        public class User
        {
            public bool isUserLogin;

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

                isUserLogin = true;
            }
        }

        public class Menu
        {
            public void ShowMenu()
            {
                bool isExit = false;
                while (!isExit)
                {
                    string selection = CmdReader("主菜单\n1.客户管理\n2.预约管理\n3.系统设置\n4.退出\n请选择: ");
                    switch (selection)
                    {
                        case "1":
                            Console.WriteLine("客户管理");
                            break;
                        case "2":
                            Console.WriteLine("预约管理");
                            break;
                        case "3":
                            Console.WriteLine("系统设置");
                            break;
                        case "4":
                        default:
                            Console.WriteLine("退出");
                            isExit = true;
                            break;
                    }
                }
            }
        }

        public class CMSController
        {
            public void Start(User user, Menu menu)
            {
                // login
                do
                {
                    user.Login();
                } while (!user.isUserLogin);

                // start Menu
                menu.ShowMenu();
            }

        }

        public static void Main(string[] args)
        {
            // 初始化用户系统
            User user = new User();
            // 初始化菜单系统
            Menu menu = new Menu();
            // 初始化控制系统
            CMSController controller = new CMSController();

            // 启动程序
            controller.Start(user, menu);

            Console.Read();
        }
    }
}
