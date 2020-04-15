using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CustomerManagement.BL
{
    public class AdressRepositary
    {
        public Address Retrieve(int adressId)
        {
            //Create the instance of Address class
            //Pass in the requested Id
            Address address = new Address(adressId);

            if (adressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Bag End";
                address.StreetLine2 = "Bag shot row";
                address.State = "Shire";
                address.PostalCode = "144";
                address.Country = "Middle Earth";
                address.City = "Hobbiton";
              

            }
            return address;
        }
        //Retrieve all the address of the same customer
        //we use IEnumerable of a sequence of data, it s more flexible
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var addressList = new List<Address>();

            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bag shot row",
                State = "Shire",
                PostalCode = "144",
                Country = "Middle Earth",
                City = "Hobbiton"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Green Dragon",
                State = "Shire",
                PostalCode = "146",
                Country = "Middle Earth",
                City = "Bywater"
            };
            addressList.Add(address);

            return addressList;
        }
        public bool Save(Address address)
        {
            var success = true;

            if (address.HasChanges)
            {
                if (address.IsValid)
                {
                    if (address.IsNew)
                    {
                        //Call an insert stored procedure
                    }
                    else
                    {
                        //Call an update stored procedure
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
