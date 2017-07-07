using System;
using System.Collections.Generic;
using ZwShop.Services.Orders;

namespace ZwShop.Services.Products
{
    public partial interface IProductService
    {
        #region Methods

        #region Products
        void MarkProductAsDeleted(int productId);

        List<Product> GetAllProducts();

        List<Product> GetAllProducts(bool showHidden);

        List<Product> GetAllProducts(int pageSize, int pageIndex,
            out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            int pageSize, int pageIndex, out int totalRecords);

        List<Product> GetAllProducts(string keywords,
            bool searchDescriptions, int pageSize, int pageIndex, out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);


        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
            List<int> filteredSpecs, out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
            List<int> filteredSpecs, ProductSortingEnum orderBy, out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax,
            string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, int languageId,
            ProductSortingEnum orderBy, out int totalRecords);

        List<Product> GetAllProducts(int categoryId,
            int BrandId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax,
            int relatedToProductId, string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, int languageId,
            ProductSortingEnum orderBy, out int totalRecords);

        List<Product> GetAllProductsDisplayedOnHomePage();
        

        Product GetProductById(int productId);
        

        void InsertProduct(Product product);

        void UpdateProduct(Product product);


        #endregion

        #region Product variants

        List<ProductVariant> GetLowStockProductVariants();

        ProductVariant GetProductVariantById(int productVariantId);

        ProductVariant GetProductVariantBySKU(string sku);
        
        List<ProductVariant> GetAllProductVariants(int categoryId,
            int BrandId, string keywords,
            int pageSize, int pageIndex, out int totalRecords);
        
        void InsertProductVariant(ProductVariant productVariant);

        void UpdateProductVariant(ProductVariant productVariant);

        List<ProductVariant> GetProductVariantsByProductId(int productId);
        
        List<ProductVariant> GetProductVariantsByProductId(int productId, bool showHidden);

        List<ProductVariant> GetProductVariantsRestrictedByDiscountId(int discountId);

        void MarkProductVariantAsDeleted(int productVariantId);

        void AdjustInventory(int productVariantId, bool decrease,
            int quantity, string attributesXml);

        #endregion
        
        #region Product pictures
        void DeleteProductPicture(int productPictureId);

        ProductPicture GetProductPictureById(int productPictureId);

        void InsertProductPicture(ProductPicture productPicture);

        void UpdateProductPicture(ProductPicture productPicture);

        List<ProductPicture> GetProductPicturesByProductId(int productId);
        #endregion

        #region Product reviews

        ProductReview GetProductReviewById(int productReviewId);

        List<ProductReview> GetProductReviewByProductId(int productId);

        void DeleteProductReview(int productReviewId);

        List<ProductReview> GetAllProductReviews();

        ProductReview InsertProductReview(int productId,
            int customerId, string title,
            string reviewText, int rating, int helpfulYesTotal,
            int helpfulNoTotal, bool isApproved, DateTime createdOn);

        ProductReview InsertProductReview(int productId,
            int customerId, string title,
            string reviewText, int rating, int helpfulYesTotal,
            int helpfulNoTotal, bool isApproved, DateTime createdOn, bool notify);

        ProductReview InsertProductReview(int productId,
            int customerId, string ipAddress, string title,
            string reviewText, int rating, int helpfulYesTotal,
            int helpfulNoTotal, bool isApproved, DateTime createdOn, bool notify);

        void UpdateProductReview(ProductReview productReview);

        void SetProductRatingHelpfulness(int productReviewId, bool wasHelpful);
        
        #endregion

        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether "Recently viewed products" feature is enabled
        /// </summary>
        bool RecentlyViewedProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of "Recently viewed products"
        /// </summary>
        int RecentlyViewedProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Recently added products" feature is enabled
        /// </summary>
        bool RecentlyAddedProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of "Recently added products"
        /// </summary>
        int RecentlyAddedProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a number of "Cross-sells"
        /// </summary>
        int CrossSellsNumber { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on search products page
        /// </summary>
        int SearchPageProductsPerPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to displays a button from AddThis.com on your product pages
        /// </summary>
        bool ShowShareButton { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Compare products" feature is enabled
        /// </summary>
        bool CompareProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets "List of products purchased by other customers who purchased the above" option is enable
        /// </summary>
        bool ProductsAlsoPurchasedEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of products also purchased by other customers to display
        /// </summary>
        int ProductsAlsoPurchasedNumber { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to notify about new product reviews
        /// </summary>
        bool NotifyAboutNewProductReviews { get; set; }

        #endregion
    }
}
