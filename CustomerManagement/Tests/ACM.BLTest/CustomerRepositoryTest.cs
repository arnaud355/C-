using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerManagement.BL;
using System.Collections.Generic;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            var customerRepositary = new CustomerRepositary();
            var expected = new Customer(1)
            {
                
                LastName = "Baggins",
                FirstName = "Bilbo",
                EmailAddress = "fbaggins@hobbiton.me"
            };

            var actual = customerRepositary.Retrieve(1);

            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            
        }
        [TestMethod]
        public void RetrieveExistingWithAddress()
        {
            var customerRepositary = new CustomerRepositary();

            var expected = new Customer(1)
            {
                LastName = "Baggins",
                FirstName = "Bilbo",
                EmailAddress = "fbaggins@hobbiton.me",
                //We iumplement the relationship between customer and address
                AddressList = new List<Address>()
                    {
                        new Address()
                        {
                             AddressType = 1,
                             StreetLine1 = "Bag End",
                             StreetLine2 = "Bag shot row",
                             State = "Shire",
                             PostalCode = "144",
                             Country = "Middle Earth",
                             City = "Hobbiton"
                        },
                         new Address()
                        {
                             AddressType = 2,
                             StreetLine1 = "Green Dragon",
                             StreetLine2 = "Bag shot row",
                             State = "Shire",
                             PostalCode = "146",
                             Country = "Middle Earth",
                             City = "Bywater"
                        }
                    }

            };
            var actual = customerRepositary.Retrieve(1);

            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.FirstName, actual.FirstName);

            for(int i = 0;i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, actual.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);
            }
        }
    }
}
