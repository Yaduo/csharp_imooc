using System;
using Microsoft.Extensions.DependencyInjection;

namespace CMS
{
    partial class Program
    {
        public static string CmdReader(string instruction)
        {
            Console.Write(instruction);
            string cmd = Console.ReadLine();
            return cmd;
        }

        public static void Main(string[] args)
        {
            // 创建 IOC 反转控制容器
            var collection = new ServiceCollection();

            // 注册服务
            collection.AddScoped<IUser, User>();
            collection.AddScoped<IMenu, Menu>();
            collection.AddScoped<ICMSController, CMSController>();

            // 创建BuildServiceProvider，提取cmsController实例
            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            var cmsController = serviceProvider.GetService<ICMSController>();

            cmsController.Start();

            Console.Read();
        }
    }
}
