using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using ZwShop.Services.Audit;
using ZwShop.Services.Caching;
using ZwShop.Services.Categories;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Data;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Brands;
using ZwShop.Services.Media;
using ZwShop.Services.Messages;
using ZwShop.Services.Orders;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial class ProductService : IProductService
    {
        #region Constants
        private const string PRODUCTS_BY_ID_KEY = "Shop.product.id-{0}";
        private const string PRODUCTVARIANTS_ALL_KEY = "Shop.productvariant.all-{0}-{1}";
        private const string PRODUCTVARIANTS_BY_ID_KEY = "Shop.productvariant.id-{0}";
        private const string TIERPRICES_ALLBYPRODUCTVARIANTID_KEY = "Shop.tierprice.allbyproductvariantid-{0}";
        private const string CUSTOMERROLEPRICES_ALL_KEY = "Shop.customerroleproductprice.all-{0}";
        private const string PRODUCTS_PATTERN_KEY = "Shop.product.";
        private const string PRODUCTVARIANTS_PATTERN_KEY = "Shop.productvariant.";
        private const string TIERPRICES_PATTERN_KEY = "Shop.tierprice.";
        private const string CUSTOMERROLEPRICES_PATTERN_KEY = "Shop.customerroleproductprice.";
        #endregion

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public ProductService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion




        public void MarkProductAsDeleted(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(bool showHidden)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(string keywords, bool searchDescriptions, int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, ProductSortingEnum orderBy, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, int languageId, ProductSortingEnum orderBy, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int categoryId, int BrandId, int productTagId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, int relatedToProductId, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, int languageId, ProductSortingEnum orderBy, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProductsDisplayedOnHomePage()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetLowStockProductVariants()
        {
            throw new NotImplementedException();
        }

        public ProductVariant GetProductVariantById(int productVariantId)
        {
            throw new NotImplementedException();
        }

        public ProductVariant GetProductVariantBySKU(string sku)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetAllProductVariants(int categoryId, int BrandId, string keywords, int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public void InsertProductVariant(ProductVariant productVariant)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductVariant(ProductVariant productVariant)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetProductVariantsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetProductVariantsByProductId(int productId, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetProductVariantsRestrictedByDiscountId(int discountId)
        {
            throw new NotImplementedException();
        }

        public void MarkProductVariantAsDeleted(int productVariantId)
        {
            throw new NotImplementedException();
        }

        public void AdjustInventory(int productVariantId, bool decrease, int quantity, string attributesXml)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductPicture(int productPictureId)
        {
            throw new NotImplementedException();
        }

        public ProductPicture GetProductPictureById(int productPictureId)
        {
            throw new NotImplementedException();
        }

        public void InsertProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public List<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductReview GetProductReviewById(int productReviewId)
        {
            throw new NotImplementedException();
        }

        public List<ProductReview> GetProductReviewByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductReview(int productReviewId)
        {
            throw new NotImplementedException();
        }

        public List<ProductReview> GetAllProductReviews()
        {
            throw new NotImplementedException();
        }

        public ProductReview InsertProductReview(int productId, int customerId, string title, string reviewText, int rating, int helpfulYesTotal, int helpfulNoTotal, bool isApproved, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public ProductReview InsertProductReview(int productId, int customerId, string title, string reviewText, int rating, int helpfulYesTotal, int helpfulNoTotal, bool isApproved, DateTime createdOn, bool notify)
        {
            throw new NotImplementedException();
        }

        public ProductReview InsertProductReview(int productId, int customerId, string ipAddress, string title, string reviewText, int rating, int helpfulYesTotal, int helpfulNoTotal, bool isApproved, DateTime createdOn, bool notify)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductReview(ProductReview productReview)
        {
            throw new NotImplementedException();
        }

        public void SetProductRatingHelpfulness(int productReviewId, bool wasHelpful)
        {
            throw new NotImplementedException();
        }

        public bool RecentlyViewedProductsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int RecentlyViewedProductsNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool RecentlyAddedProductsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int RecentlyAddedProductsNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int CrossSellsNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SearchPageProductsPerPage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ShowShareButton
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CompareProductsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ProductsAlsoPurchasedEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ProductsAlsoPurchasedNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool NotifyAboutNewProductReviews
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
