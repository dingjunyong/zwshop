using System.Collections.Generic;
using ZwShop.Services.Products;

namespace ZwShop.Services.Orders
{
    public partial class ShoppingCart : List<ShoppingCartItem>
    {
        public bool IsRecurring
        {
            get
            {
                foreach (ShoppingCartItem sci in this)
                {
                    ProductVariant productVariant = sci.ProductVariant;
                    if (productVariant != null)
                    {
                        if (productVariant.IsRecurring)
                        {
                            return true;
                        }   
                    }
                }
                return false;
            }
        }
        public int TotalProducts
        {
            get
            {
                int result = 0;
                foreach (ShoppingCartItem sci in this)
                {
                    result += sci.Quantity;
                }

                return result;
            }
        }
    }
}
