using System;
using System.Xml;
using ZwShop.Services.Audit;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Tasks;

namespace ZwShop.Services.Caching
{
    /// <summary>
    /// Clear cache schedueled task implementation
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
        /// <summary>
        /// Executes the clear cache task
        /// </summary>
        /// <param name="node">XML node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            try
            {
                new ShopStaticCache().Clear();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.AdministrationArea, "清除缓存发生错误", ex);
            }
        }
    }
}
