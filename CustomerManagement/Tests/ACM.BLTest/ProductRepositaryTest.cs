using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerManagement.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositaryTest
    {
        [TestMethod]
        public void RetrieveTest()
        {

            var productRepositary = new ProductRepositary();
            var expected = new Product(2)
            {
                ProductName = "SunFlower",
                ProductDescription = "Assorted set of 4 mini sun flowers",
                CurrentPrice = 15.96M
             };

            var actual = productRepositary.Retrieve(2);

            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
           
        }
        [TestMethod]
        public void SaveTestValid()
        {
            //Arrange
            var productRepositary = new ProductRepositary();
            var updatedProduct = new Product(2)
            {
                ProductName = "SunFlower",
                ProductDescription = "Assorted set of 4 mini sun flowers",
                CurrentPrice = 18M,
                HasChanges = true
            };

            //Act
            var actual = productRepositary.Save(updatedProduct);

            //Assert
            Assert.AreEqual(true,actual);        

        }
        [TestMethod]
        public void SaveTestMissingPrice()
        {
            //Arrange
            var productRepositary = new ProductRepositary();
            var updatedProduct = new Product(2)
            {
                ProductName = "SunFlower",
                ProductDescription = "Assorted set of 4 mini sun flowers",
                CurrentPrice = null,
                HasChanges = true
            };

            //Act
            var actual = productRepositary.Save(updatedProduct);

            //Assert
            Assert.AreEqual(false, actual);         

        }
    }
}
