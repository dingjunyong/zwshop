//------------------------------------------------------------------------------
// The contents of this file are subject to the ShopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.

// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is ShopCommerce.
// The Initial Developer of the Original Code is ShopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.Products.Attributes
{
    /// <summary>
    /// Represents a product attribute
    /// </summary>
    public partial class ProductAttribute : BaseEntity
    {
        #region Fields
        private List<ProductAttributeLocalized> _paLocalized;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the product attribute identifier
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region Localizable methods/properties

        /// <summary>
        /// Gets the localized name
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Localized name</returns>
        public string GetLocalizedName(int languageId)
        {
            if (ShopContext.Current.LocalizedEntityPropertiesEnabled)
            {
                if (languageId > 0)
                {
                    if (_paLocalized == null)
                        _paLocalized = IoC.Resolve<IProductAttributeService>().GetProductAttributeLocalizedByProductAttributeId(this.ProductAttributeId);

                    var temp1 = _paLocalized.FirstOrDefault(cl => cl.LanguageId == languageId);
                    if (temp1 != null && !String.IsNullOrWhiteSpace(temp1.Name))
                        return temp1.Name;
                }
            }

            return this.Name;
        }

        /// <summary>
        /// Gets the localized name 
        /// </summary>
        public string LocalizedName
        {
            get
            {
                return GetLocalizedName(ShopContext.Current.WorkingLanguage.LanguageId);
            }
        }

        /// <summary>
        /// Gets the localized description
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Localized description</returns>
        public string GetLocalizedDescription(int languageId)
        {
            if (ShopContext.Current.LocalizedEntityPropertiesEnabled)
            {
                if (languageId > 0)
                {
                    if (_paLocalized == null)
                        _paLocalized = IoC.Resolve<IProductAttributeService>().GetProductAttributeLocalizedByProductAttributeId(this.ProductAttributeId);

                    var temp1 = _paLocalized.FirstOrDefault(cl => cl.LanguageId == languageId);
                    if (temp1 != null && !String.IsNullOrWhiteSpace(temp1.Description))
                        return temp1.Description;
                }
            }

            return this.Description;
        }

        /// <summary>
        /// Gets the localized description 
        /// </summary>
        public string LocalizedDescription
        {
            get
            {
                return GetLocalizedDescription(ShopContext.Current.WorkingLanguage.LanguageId);
            }
        }
        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the localized product attributes
        /// </summary>
        public virtual ICollection<ProductAttributeLocalized> NpProductAttributeLocalized { get; set; }

        /// <summary>
        /// Gets the product variant attributes
        /// </summary>
        public virtual ICollection<ProductVariantAttribute> NpProductVariantAttributes { get; set; }
        
        #endregion
    }
}
