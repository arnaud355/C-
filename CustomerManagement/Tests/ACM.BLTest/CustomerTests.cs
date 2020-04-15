using System;
using CustomerManagement.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //Arrange
            Customer customer = new Customer();
            //or var  customer = new Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";
            //string expected = "Baggins, Bilbo";
            string expected = customer.ToString();
            //Act
            string actual = customer.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //Arrange
            Customer customer = new Customer()
            {
                FirstName = "Bilbo"
            };
            
            string expected = "Bilbo";
           

            //Act
            string actual = customer.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //Arrange
            Customer c1 = new Customer();
            c1.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            Customer c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            Customer c3 = new Customer();
            c3.FirstName = "Rosie";
            Customer.InstanceCount += 1;

          
            //Act
            

            //Assert
            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            //Arrange
            Customer customer = new Customer()
            {
                LastName = "Baggins",
                EmailAddress = "fbaggins@hobbiton.me"
            };

            var expected = true;
            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
