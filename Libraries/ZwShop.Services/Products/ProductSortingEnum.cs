namespace ZwShop.Services.Products
{
    /// <summary>
    /// 产品排序方式
    /// </summary>
    public enum ProductSortingEnum : int
    {
        /// <summary>
        /// Position (display order)
        /// </summary>
        Position = 0,
        /// <summary>
        /// Name
        /// </summary>
        Name = 5,
        /// <summary>
        /// Price
        /// </summary>
        Price = 10,
        /// <summary>
        /// Product creation date
        /// </summary>
        CreatedOn = 15,

    }
}