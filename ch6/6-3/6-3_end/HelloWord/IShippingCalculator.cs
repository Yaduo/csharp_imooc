using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    interface IShippingCalculator
    {
        float CalculateShipping(Order order);
    }
}
