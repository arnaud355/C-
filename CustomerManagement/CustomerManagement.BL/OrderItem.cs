using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class OrderItem
    {
        public OrderItem()
        {
            /*Default constructor is implicit, but when it 's overloaded
             you need to write the default constructor
             */
        }
        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
      
        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int Quantity { get; set; }

        public OrderItem Retrieve(int orderItemId)
        {
            //Code that retrieve the defined customer

            return new OrderItem();
        }
       
        public bool Save()
        {
            //Code that save the defined order item

            return true;
        }
        public bool Validate()
        {
            var isValid = true;

            if (Quantity <= 0)
                isValid = false;
            if (ProductId <= 0)
                isValid = false;
            if (PurchasePrice == null)
                isValid = false;

            return isValid;
        }
    }
}
