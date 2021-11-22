using System;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ProductList();
            list.Add(new Product()
            {
                Id = 1, 
                Price = 100
            }); 


            Console.Read();
        }
    }
}
