using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Categories;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Brands;
using ZwShop.Services.Media;
using ZwShop.Common;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// …Ã∆∑±Ì
    /// </summary>
    public partial class Product : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        #endregion


        #region Custom Properties
        /// <summary>
        /// Gets the product variants
        /// </summary>
        public List<ProductVariant> ProductVariants
        {
            get
            {
                return IoC.Resolve<IProductService>().GetProductVariantsByProductId(this.Id);
            }
        }

        /// <summary>
        /// Indicates whether Product has more than one variant
        /// </summary>
        public bool HasMultipleVariants
        {
            get
            {
                return (this.ProductVariants.Count > 1);
            }
        }

      

        public Picture DefaultPicture
        {
            get
            {
                var picture = IoC.Resolve<IPictureService>().GetPicturesByProductId(this.Id, 1).FirstOrDefault();
                return picture;
            }
        }

        public List<ProductPicture> ProductPictures
        {
            get
            {
                return IoC.Resolve<IProductService>().GetProductPicturesByProductId(this.Id);
            }
        }
        public Category Category
        {
            get
            {
                return IoC.Resolve<ICategoryService>().GetCategoryById(this.CategoryId);
            }
        }

        public Brand Brand
        {
            get
            {
                return IoC.Resolve<IBrandService>().GetBrandById(this.BrandId);
            }
        }

        public List<ProductReview> ProductReviews
        {
            get
            {
                return IoC.Resolve<IProductService>().GetProductReviewByProductId(this.Id);
            }
        }

        public ProductVariant MinimalPriceProductVariant
        {
            get
            {
                var productVariants = this.ProductVariants;
                productVariants.Sort(new GenericComparer<ProductVariant>
                    ("Price", GenericComparer<ProductVariant>.SortOrder.Ascending));
                if (productVariants.Count > 0)
                    return productVariants[0];
                else
                    return null;
            }
        }

       
        #endregion

        #region Navigation Properties

        public virtual ICollection<ProductVariant> NpProductVariants { get; set; }
        
        public virtual ICollection<ProductPicture> NpProductPictures { get; set; }
        
        public virtual ICollection<ProductReview> NpProductReviews { get; set; }
        
        #endregion
    }

}
