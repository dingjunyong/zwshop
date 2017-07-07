using System;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Represents a product variant event arguments
    /// </summary>
    public partial class ProductVariantEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the product variant
        /// </summary>
        public ProductVariant ProductVariant { get; set; }
    }
}
