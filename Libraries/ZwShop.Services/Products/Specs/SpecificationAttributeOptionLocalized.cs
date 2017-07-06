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

namespace ZwShop.Services.Products.Specs
{
    /// <summary>
    /// Represents a localized specification attribute option
    /// </summary>
    public partial class SpecificationAttributeOptionLocalized : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the localized specification attribute option identifier
        /// </summary>
        public int SpecificationAttributeOptionLocalizedId { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute option identifier
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the specification attribute option
        /// </summary>
        public virtual SpecificationAttributeOption NpSpecificationAttributeOption { get; set; }

        #endregion
    }
}