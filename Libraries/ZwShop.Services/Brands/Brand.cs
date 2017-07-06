using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;
using ZwShop.Services.Products;

namespace ZwShop.Services.Brands
{
    /// <summary>
    /// Represents a Brand
    /// </summary>
    public partial class Brand : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        #endregion

   
        #region Custom Properties

        public Picture Picture
        {
            get
            {
                return IoC.Resolve<IPictureService>().GetPictureById(this.PictureId);
            }
        }


        public List<Product> FeaturedProducts
        {
            get
            {
                int totalFeaturedRecords = 0;
                var featuredProducts = IoC.Resolve<IProductService>().GetAllProducts(0,
                    this.Id, 0, true, int.MaxValue - 1, 0, out totalFeaturedRecords);
                return featuredProducts;
            }
        }

        #endregion

      
    }
}
