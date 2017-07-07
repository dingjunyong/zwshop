using System;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Products;

namespace ZwShop.Services.Orders
{
    public partial class ShoppingCartItem : BaseEntity
    {
        #region Fields
        private ProductVariant _cachedProductVariant;
        #endregion

        #region Properties
        public int ShoppingCartTypeId { get; set; }

        public Guid CustomerSessionGuid { get; set; }

        public int ProductVariantId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        #endregion 

        #region Custom Properties

        public ShoppingCartTypeEnum ShoppingCartType
        {
            get
            {
                return (ShoppingCartTypeEnum)this.ShoppingCartTypeId;
            }
        }
        public ProductVariant ProductVariant
        {
            get
            {
                if (_cachedProductVariant == null)
                {
                    _cachedProductVariant = IoC.Resolve<IProductService>().GetProductVariantById(this.ProductVariantId);
                }
                return _cachedProductVariant;
            }
        }
        public CustomerSession CustomerSession
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerSessionByGuid(this.CustomerSessionGuid);
            }
        }
        #endregion
    }
}
