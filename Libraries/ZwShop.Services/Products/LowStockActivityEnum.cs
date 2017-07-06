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

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Represents a low stock activity (need to be synchronize with [Shop_LowStockActivity] table
    /// </summary>
    public enum LowStockActivityEnum : int
    {
        /// <summary>
        /// Nothing
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// Disable buy button
        /// </summary>
        DisableBuyButton = 1,
        /// <summary>
        /// Unpublish
        /// </summary>
        Unpublish = 2,
    }
}
