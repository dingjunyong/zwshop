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

using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Directory;

namespace ZwShop.Services.Payment
{
    /// <summary>
    /// Represents a payment info holder
    /// </summary>
    public partial class PaymentInfo
    {
        #region Properties
        /// <summary>
        /// Gets or sets a shipping address
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets an order total
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// /// <summary>
        /// Gets or sets a payment method identifier
        /// </summary>
        /// </summary>
        public int PaymentMethodId { get; set; }
        /// <summary>
        /// Gets or sets an initial (parent) order identifier if order is recurring
        /// </summary>
        public int InitialOrderId { get; set; }
        

        #endregion
    }
}
