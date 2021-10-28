using System;

namespace CMS
{
    class Program
    {
        static string CmdReader(string instruction)
        {
            Console.Write(instruction);
            string cmd = Console.ReadLine();
            return cmd;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==================客户管理系统==================");
            Console.WriteLine("请登录");

            bool isExit = false;
            do
            {
                string username;
                string password;

                username = CmdReader("用户名: ");
                if (username != "alex")
                {
                    Console.WriteLine("查无此人");
                    continue;
                }

                password = CmdReader("密码: ");
                if (password != "123456")
                {
                    Console.WriteLine("密码错误，退出系统");
                    continue;
                }

                while (!isExit)
                {
                    string selection = CmdReader("主菜单\n1.客户管理\n2.预约管理\n3.系统设置\n4.退出\n请选择：");
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
            } while (!isExit);
            Console.Read();
        }
    }
}
