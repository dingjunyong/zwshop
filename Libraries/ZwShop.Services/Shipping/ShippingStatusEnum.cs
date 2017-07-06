namespace ZwShop.Services.Shipping
{
    public enum ShippingStatusEnum : int
    {
        /// <summary>
        /// 不需要运输
        /// </summary>
        ShippingNotRequired = 10,
        /// <summary>
        /// 未出货
        /// </summary>
        NotYetShipped = 20,
        /// <summary>
        /// 运输中
        /// </summary>
        Shipped = 30,
        /// <summary>
        /// 已交付
        /// </summary>
        Delivered = 40,
    }
}
