using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public class ProductRepositary
    {
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            if (productId == 2)
            {
                product.ProductName = "SunFlower";
                product.ProductDescription = "Assorted set of 4 mini sun flowers";
                product.CurrentPrice = 15.96M;             
            }
            /*classe Object étant une classe de .Net, elle fait hérité de ses méthods
            comme ToString()*/
            Object myObject = new object();
            Console.WriteLine($"Object: {myObject.ToString()}");
            Console.WriteLine($"Product: {product.ToString()}");
            return product;
        }
        public bool Save(Product product)
        {
            //Code saved the product passed
            var success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
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
