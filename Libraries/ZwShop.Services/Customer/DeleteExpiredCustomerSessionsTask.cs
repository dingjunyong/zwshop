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
using System.Xml;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Tasks;

namespace ZwShop.Services.CustomerManagement
{
    public partial class DeleteExpiredCustomerSessionsTask : ITask
    {
        private int _deleteExpiredCustomerSessionsOlderThanMinutes = 43200; 

        public void Execute(XmlNode node)
        {
            XmlAttribute attribute1 = node.Attributes["deleteExpiredCustomerSessionsOlderThanMinutes"];
            if (attribute1 != null && !String.IsNullOrEmpty(attribute1.Value))
            {
                this._deleteExpiredCustomerSessionsOlderThanMinutes = int.Parse(attribute1.Value);
            }

            DateTime olderThan = DateTime.UtcNow;
            olderThan = olderThan.AddMinutes(-(double)this._deleteExpiredCustomerSessionsOlderThanMinutes);
            IoC.Resolve<ICustomerService>().DeleteExpiredCustomerSessions(olderThan);
        }
    }
}
