namespace ZwShop.Services.Orders
{
    /// <summary>
    /// Represents an order status enumeration (need to be synchronize with [Shop_OrderStatus] table)
    /// </summary>
    public enum OrderStatusEnum : int
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,
        /// <summary>
        /// Processing
        /// </summary>
        Processing = 20,
        /// <summary>
        /// Complete
        /// </summary>
        Complete = 30,
        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 40
    }
}
