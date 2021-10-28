using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    public class DoubleElevenShippingCalculator : IShippingCalculator
    {
        public DoubleElevenShippingCalculator()
        {
            Console.WriteLine("DoubleElevenShippingCalculator 被构造了一次");
        }

        public float CalculateShipping(Order order)
        {
            return 0f;
        }
    }
}
