
namespace ZwShop.Services.Products
{
    public enum BackordersModeEnum : int
    {
        /// <summary>
        /// No backorders
        /// </summary>
        NoBackorders = 0,
        /// <summary>
        /// Allow qty below 0
        /// </summary>
        AllowQtyBelow0 = 1,
        /// <summary>
        /// Allow qty below 0 and notify customer
        /// </summary>
        AllowQtyBelow0AndNotifyCustomer = 2,
    }
}
