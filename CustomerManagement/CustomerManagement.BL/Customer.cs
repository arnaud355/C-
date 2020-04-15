using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    /*Collaboration: (use a) une classe utilise une autre classe non en relation,
     par exemple classe CustomerRepositary utilise une instance de la classe client
     pour renseigner des données client. 

    Composition: C'est une classe qui est composée d'autres classes:
    par exemple classe order est composée de la classe client, address, liste d'orderItem
    (Implémentée comme propriété de réf, ou comme identifiant).

    héritage: définie une classe plus spécialisée que sa version mère.

    Le framework .Net à une classe nommée Object, toutes nouvelles classes créees
    en hérite.
     */
    public class Customer : EntityBase, ILoggable
    {
        /*with this(0) defaut constructor call constructor above
         and pass 0 for the id, hence the list is initialise, not null,
         with null it s call an exception
         */
        public Customer(): this(0)
        {
            /*Default constructor is implicit, but when it 's overloaded
             you need to write the default constructor.

            Overload methos: same name for methods but different signatures (parameters)
             */
        }
        public Customer(int customerId)
        {
            CustomerId = customerId;
            AddressList = new List<Address>();
        }
        public List<Address> AddressList { get; set; }
        public string EmailAddress { get; set; }
        public int CustomerId { get;private set; }
        public int CustomerType { get; set; }

        public string FullName
        {
            get 
            {
                string FullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(FullName))
                    {
                        FullName += ", ";
                    }
                    FullName += FirstName;
                }
                return FullName;
            }
        }

        //Method of the class, it s with static
        public static int InstanceCount { get; set; }

        public string FirstName { get; set; }

        //Under without the shortcurt
        //We need to create variable and add manualy a method
        private string _lastName;
        
        public string LastName
        {
            get 
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }

        }

        //public string Log()
    //{
    //  var logString = CustomerId + ": " +
    //                  FullName + " " +
    //                  "Email: " + EmailAddress + " " +
    //                  "Status: " + EntityState.ToString();
    //  return logString;
    //}
    //Raccourci ci-dessous:
        public string Log() =>
      $"{CustomerId}: {FullName} Email: {EmailAddress} Status: {EntityState.ToString()}";

        /*We have setting for that method ToString() send:
         "System.Object" if it's mother class Object,
         date and id number for or for Order class and full name
         for instance of customer class.
         It's polymorphism, based on inheritance.
        */
        public override string ToString() => FullName;

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(EmailAddress))
                isValid = false;

            if (string.IsNullOrWhiteSpace(LastName))
                isValid = false;

            return isValid;
        }

    }
}
