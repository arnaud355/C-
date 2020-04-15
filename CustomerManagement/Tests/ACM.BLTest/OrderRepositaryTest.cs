using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerManagement.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class OrderRepositaryTest
    {
        [TestMethod]
        public void RetrieveOrderDisplayTest()
        {
            var orderRepositary = new OrderRepositary();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))

            };

            var actual = orderRepositary.Retrieve(10);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
          
        }
       
    }
}
