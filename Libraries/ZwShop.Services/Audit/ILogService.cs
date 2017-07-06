using System;
using ZwShop.Common;

namespace ZwShop.Services.Audit
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public partial interface ILogService
    {
        void DeleteLog(int logId);

        void ClearLog();

        PagedList<Log> GetAllLogs(DateTime? createdOnFrom,
           DateTime? createdOnTo, string message,  int logTypeId, int pageIndex, int pageSize);

        Log GetLogById(int logId);
        
        Log InsertLog(LogTypeEnum logType, string message, string exception);

        Log InsertLog(LogTypeEnum logType, string message, Exception exception);

        Log InsertLog(LogTypeEnum logType, int severity, string message,
            Exception exception, string IPAddress,
            int customerId, string pageUrl);
    }
}
