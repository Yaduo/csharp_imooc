using System;
using System.Reflection;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // 定位类                      命名空间.类名，   项目名称
            const string classLocation = "HelloWord.List, HelloWord";

            // 获取 List 类型对象
            Type objectType = Type.GetType(classLocation);

            // 通过类型实例化
            object obj = Activator.CreateInstance(objectType);

            // 调用“Add”方法
            MethodInfo add = objectType.GetMethod("Add");
            add.Invoke(obj, null);

            Console.Read();
        }
    }
}
