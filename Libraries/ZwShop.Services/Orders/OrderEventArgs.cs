
using System;

namespace ZwShop.Services.Orders
{
    /// <summary>
    /// Represents an order event arguments
    /// </summary>
    public partial class OrderEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the order
        /// </summary>
        public Order Order { get; set; }
    }
}
