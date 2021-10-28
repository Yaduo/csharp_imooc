using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord
{
    public interface IOrderProcessor
    {
        public void Process(Order order);
    }
}
