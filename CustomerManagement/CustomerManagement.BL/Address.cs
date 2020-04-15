using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class Address : EntityBase
    {
        public Address()
        {
            /*Default constructor is implicit, but when it 's overloaded
             you need to write the default constructor
             */
        }
        public Address(int addressId)
        {
            AddressId = addressId;
        }

        public int AddressId { get; private set; }
        public int AddressType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }

        public override bool Validate()
        {
            var isValid = true;

            if (PostalCode == null)
                isValid = false;
         

            return isValid;
        }
    }
}
