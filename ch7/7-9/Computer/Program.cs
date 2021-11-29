using System;
using System.IO;
using System.Runtime.Loader;
using System.Collections;
using System.Collections.Generic;
using Computer.SDK;

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
            var metaFiles = Directory.GetFiles(USBInterface);
            var devicesList = new List<IUSB>();

            foreach (var meta in metaFiles)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(meta);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var interfaceList = type.GetInterfaces();
                    foreach (var i in interfaceList)
                    {
                        if (i.Name == "IUSB")
                        {
                            IUSB device = (IUSB)Activator.CreateInstance(type);
                            devicesList.Add(device);
                        }
                    }
                }
            }

            foreach (var devices in devicesList)
            {
                devices.GetInfo();
                devices.Read();
                devices.Wirte();
            }

            Console.Read();
        }
    }
}
