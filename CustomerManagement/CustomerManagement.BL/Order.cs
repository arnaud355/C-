using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class Order : EntityBase, ILoggable
    {
        public Order() : this(0)
        {
            /*Default constructor is implicit, but when it 's overloaded
             you need to write the default constructor
             */
        }
        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }
        //DateTimeOffset take care of the decalage horaire
        /*le point d'interrogation permet de prendre en compte valeur null, 
        pas de date par defaut*/
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public List<OrderItem> OrderItems { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }

        public string Log() =>
     $"{OrderId}: Date: {this.OrderDate.Value.Date} Status: {this.EntityState.ToString()}";

        public override string ToString() => $"{OrderDate.Value.Date} ({OrderId})";

        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null)
                isValid = false;

            return isValid;
        }
    }
}
