using System;
using System.Linq;
using System.Web;
using ZwShop.Services.Caching;
using ZwShop.Services.Data;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Audit
{
    /// <summary>
    /// Log service
    /// </summary>
    public partial class LogService : ILogService
    {
        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public LogService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion



        public void DeleteLog(int logId)
        {
            throw new NotImplementedException();
        }

        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        public PagedList<Log> GetAllLogs(DateTime? createdOnFrom, DateTime? createdOnTo, string message, int logTypeId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Log GetLogById(int logId)
        {
            throw new NotImplementedException();
        }

        public Log InsertLog(LogTypeEnum logType, string message, string exception)
        {
            throw new NotImplementedException();
        }

        public Log InsertLog(LogTypeEnum logType, string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public Log InsertLog(LogTypeEnum logType, int severity, string message, Exception exception, string IPAddress, int customerId, string pageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
