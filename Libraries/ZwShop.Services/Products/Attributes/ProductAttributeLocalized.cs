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

namespace ZwShop.Services.Products.Attributes
{
    /// <summary>
    /// Represents a localized product attribute
    /// </summary>
    public partial class ProductAttributeLocalized : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the localized product attribute identifier
        /// </summary>
        public int ProductAttributeLocalizedId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute identifier
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the product attribute
        /// </summary>
        public virtual ProductAttribute NpProductAttribute { get; set; }

        #endregion
    }
}