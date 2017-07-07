using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;
using ZwShop.Services.Orders;

namespace ZwShop.Services.Products
{
    public partial class ProductVariant : BaseEntity
    {

        #region Properties

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 是否免费送货
        /// </summary>
        public bool IsFreeShipping { get; set; }

        /// <summary>
        /// 指示是否管理库存
        /// </summary>
        public int ManageInventory { get; set; }

        public int StockQuantity { get; set; }

        
        public int MinStockQuantity { get; set; }


        public int NotifyAdminForQuantityBelow { get; set; }


        public int Backorders { get; set; }

  
        public decimal Price { get; set; }


        public decimal OldPrice { get; set; }

        public decimal ProductCostPrice { get; set; }


        public int PictureId { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        #endregion


        #region Custom Properties

       


        /// <summary>
        /// Gets the product
        /// </summary>
        public Product Product
        {
            get
            {
                return IoC.Resolve<IProductService>().GetProductById(this.ProductId);
            }
        }


        /// <summary>
        /// Gets the full product name
        /// </summary>
        public string FullProductName
        {
            get
            {
                Product product = this.Product;
                if (product != null)
                {
                    if (!String.IsNullOrEmpty(this.Name))
                        return product.Name + " (" + this.Name + ")";
                    return product.Name;
                }
                return string.Empty;
            }
        }

        public Picture Picture
        {
            get
            {
                return IoC.Resolve<IPictureService>().GetPictureById(this.PictureId);
            }
        }


        #endregion

        #region Navigation Properties



        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual Product NpProduct { get; set; }

        
        #endregion
    }
}
