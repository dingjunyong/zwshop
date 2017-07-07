namespace ZwShop.Services.Products
{
    /// <summary>
    /// ÏÛÄ½¡¢ÓÐ°ïÖú¡¢ÔÞ ¼ÇÂ¼±í
    /// </summary>
    public partial class ProductReviewHelpfulness : BaseEntity
    {
        #region Properties
        public int ProductReviewId { get; set; }

        public int CustomerId { get; set; }

        public bool WasHelpful { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the product review
        /// </summary>
        public virtual ProductReview NpProductReview { get; set; }

        #endregion
    }
}