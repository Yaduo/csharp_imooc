using System;
using System.IO;
using System.Runtime.Loader;

namespace Computer
{
    class Program
    {
        static void Main(string[] args)
        {

            // 程序路径
            Console.WriteLine(Environment.CurrentDirectory);

            // 文件读写操作
            var USBInterface = Path.Combine(Environment.CurrentDirectory, "USB");
            var devices = Directory.GetFiles(USBInterface);

            foreach(var device in devices)
            {
                // mac 需要去掉 “.DS_Store” 文件
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(device);
                var types = assembly.GetTypes();
                foreach(var type in types)
                {
                    Console.WriteLine(type.Name);
                }

            }
            




            Console.Read();
        }
    }
}
