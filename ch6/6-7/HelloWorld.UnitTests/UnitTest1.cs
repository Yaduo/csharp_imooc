using HelloWord;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelloWorld.UnitTests
{
    [TestClass]
    public class OrderProcessorTest
    {
        // 被测方法_条件_期望结果
        [TestMethod]
        public void Process_OrderUnshiped_Add5RMB()
        {
            var orderProcess = new OrderProcessor(new FakeShippingCalculator());
            var order = new Order
            {
                TotalPrice = 30f
            };
            orderProcess.Process(order);

            Assert.IsTrue(order.IsShipped);
            Assert.AreEqual(order.Shipment.Cost, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsShiped_ThrowException()
        {
            var orderProcess = new OrderProcessor(new FakeShippingCalculator());
            var order = new Order
            {
                TotalPrice = 30f
            };
            order.IsShipped = true;
            orderProcess.Process(order);
        }

        public class FakeShippingCalculator : IShippingCalculator
        {
            public float CalculateShipping(Order order)
            {
                return 5;
            }
        }
    }
}
