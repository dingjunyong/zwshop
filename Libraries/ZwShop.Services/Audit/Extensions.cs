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

using System.Collections.Generic;

namespace ZwShop.Services.Audit
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Find activity log type by system keyword
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Activity log type item</returns>
        public static ActivityLogType FindBySystemKeyword(this List<ActivityLogType> source,
            string systemKeyword)
        {
            for (int i = 0; i < source.Count; i++)
                if (source[i].SystemKeyword.ToLowerInvariant().Equals(systemKeyword.ToLowerInvariant()))
                    return source[i];
            return null;
        }
    }
}
