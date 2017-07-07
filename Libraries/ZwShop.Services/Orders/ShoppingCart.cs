using System.Collections.Generic;
using ZwShop.Services.Products;

namespace ZwShop.Services.Orders
{
    public partial class ShoppingCart : List<ShoppingCartItem>
    {

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
