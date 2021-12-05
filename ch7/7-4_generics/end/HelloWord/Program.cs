using System;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numberlist = new List();
            var numberlist = new GenericList<int>();
            numberlist.Add(1);
            numberlist.Add(2);

            //var productList = new ProductList();
            var productList = new GenericList<Product>();
            productList.Add(new Product()
            {
                Id = 1, 
                Price = 100
            });
            productList.Add(new Product()
            {
                Id = 2,
                Price = 200
            });
            
            var dic = new System.Collections.Generic.Dictionary<string, Product>();
            dic.Add("123", new Product());
            dic.Add("234", new Product());
            dic.Add("345", new Product());

            Product product;
            dic.TryGetValue("123", out product);

            Nullable<int> number = new Nullable<int>();
            Console.WriteLine(number.HasValue);

            var number2 = new Nullable<int>(5);
            number2.GetValueOrDefault();

            Console.Read();
        }
    }
}
