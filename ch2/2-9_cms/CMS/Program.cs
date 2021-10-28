using System;

namespace CMS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==================客户管理系统==================");
            Console.WriteLine("请登录");

            string username;
            string password;

            Console.WriteLine("用户名: ");
            username = Console.ReadLine();
            if (username == "alex")
            {
                Console.WriteLine("密码: ");
                password = Console.ReadLine();
                if (password == "123456")
                {
                    Console.WriteLine("主菜单");
                    Console.WriteLine("1.客户管理");
                    Console.WriteLine("2.预约管理");
                    Console.WriteLine("3.系统设置");
                    Console.WriteLine("4.退出");

                    Console.Write("请选择:");
                    string selection = Console.ReadLine();

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
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("密码错误，退出系统");
                }
            }
            else
            {
                Console.WriteLine("查无此人");
            }
            
            Console.Read();
        }
    }
}
