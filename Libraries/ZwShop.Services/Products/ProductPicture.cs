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

using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Represents a product picture mapping
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ProductPicture identifier
        /// </summary>
        public int ProductPictureId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
        #endregion 
        
        #region Custom Properties
        /// <summary>
        /// Gets the picture
        /// </summary>
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
        /// Gets the picture
        /// </summary>
        public virtual Picture NpPicture { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual Product NpProduct { get; set; }

        #endregion
    }

}