using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class CustomerRepositary
    {
        public CustomerRepositary()
        {
            addressRepositary = new AdressRepositary(); 
        }
        private AdressRepositary addressRepositary { get; set; }
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);

            if (customerId == 1)
            {
                customer.LastName = "Baggins";
                customer.FirstName = "Bilbo";
                customer.EmailAddress = "fbaggins@hobbiton.me";
                //Etablish the link between CustomerRepositary and addressRepositary
                customer.AddressList = addressRepositary.RetrieveByCustomerId(customerId).ToList();
            }
            return customer;
        }
       public bool Save(Customer customer)
        {
            //Code saved the customer passed
         
            var success = true;

            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
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
