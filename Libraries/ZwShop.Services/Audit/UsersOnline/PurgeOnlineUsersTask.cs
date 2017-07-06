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

namespace ZwShop.Services.Audit.UsersOnline
{
    /// <summary>
    /// Purge onlie users schedueled task implementation
    /// </summary>
    public partial class PurgeOnlineUsersTask : ITask
    {
        /// <summary>
        /// Executes the clear cache task
        /// </summary>
        /// <param name="node">XML node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            try
            {
                IoC.Resolve<IOnlineUserService>().PurgeUsers();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.CustomerError, "Error purging online users.", ex);
            }
        }
    }
}
