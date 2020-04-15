using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {
            /*Default constructor is implicit, but when it 's overloaded
             you need to write the default constructor
             */
        }
        public Product(int productId)
        {
            ProductId = productId;
        }

        //The ? is for distingue null value and zero value
        public decimal? CurrentPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        //public string ProductName { get; set; }

        private string _ProductName;
        public string ProductName
        {
            get
            {
                //Static method
                return _ProductName.InsertSpaces();
            }
            set
            {
                _ProductName = value;
            }

        }

        public string Log() =>
      $"{ProductId}: {ProductName} Detail: {ProductDescription} Status: {EntityState.ToString()}";

        /*Object, de .Net etant la classe mère de tous, 
        ses classes filles héritent de ses méthodes, pour
        donner la priorité d'une méthode envers une classe
        fille, on applique override*/
        public override string ToString() => ProductName;
        /*
         Version longue
            public override string ToString()
        {
            return ProductName;
        }*/

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName))
                isValid = false;

            if (CurrentPrice == null)
                isValid = false;

            return isValid;
        }
    }
}
