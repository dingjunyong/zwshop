using System;

namespace ZwShop.Services.Products
{
    public partial class ProductEventArgs : EventArgs
    {
        public Product Product { get; set; }
    }
}
