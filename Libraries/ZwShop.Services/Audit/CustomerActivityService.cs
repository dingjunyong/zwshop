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
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Infrastructure;
using ZwShop.Common;
using ZwShop.Common.Utils;
using ZwShop.Services.Data;
using Dapper;

namespace ZwShop.Services.Audit
{
    /// <summary>
    /// Customer activity service
    /// </summary>
    public class CustomerActivityService : ICustomerActivityService
    {
        #region Constants
        private const string ACTIVITYTYPE_ALL_KEY = "Shop.activitytype.all";
        private const string ACTIVITYTYPE_BY_ID_KEY = "Shop.activitytype.id-{0}";
        private const string ACTIVITYTYPE_PATTERN_KEY = "Shop.activitytype.";
        #endregion

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
        public CustomerActivityService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void InsertActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException("activityLogType");

            activityLogType.SystemKeyword = CommonHelper.EnsureNotNull(activityLogType.SystemKeyword);
            activityLogType.SystemKeyword = CommonHelper.EnsureMaximumLength(activityLogType.SystemKeyword, 50);
            activityLogType.Name = CommonHelper.EnsureNotNull(activityLogType.Name);            
            activityLogType.Name = CommonHelper.EnsureMaximumLength(activityLogType.Name, 100);


            using (var connection = _context.OpenConnection()) 
            {
                connection.Execute(new CommandDefinition());
            }
            if (this.CacheEnabled)
                _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
        }

        /// <summary>
        /// Updates an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void UpdateActivityType(ActivityLogType activityLogType)
        {
            //if (activityLogType == null)
            //    throw new ArgumentNullException("activityLogType");

            //activityLogType.SystemKeyword = CommonHelper.EnsureNotNull(activityLogType.SystemKeyword);
            //activityLogType.SystemKeyword = CommonHelper.EnsureMaximumLength(activityLogType.SystemKeyword, 50);
            //activityLogType.Name = CommonHelper.EnsureNotNull(activityLogType.Name);
            //activityLogType.Name = CommonHelper.EnsureMaximumLength(activityLogType.Name, 100);

            
            ////if (!_context.IsAttached(activityLogType))
            ////    _context.ActivityLogTypes.Attach(activityLogType);

            ////_context.SaveChanges();


            //if (this.CacheEnabled)
            //    _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
            throw new NotImplementedException();
        }
                
        /// <summary>
        /// Deletes an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        public void DeleteActivityType(int activityLogTypeId)
        {
            //var activityLogType = GetActivityTypeById(activityLogTypeId);
            //if (activityLogType == null)
            //    return;

            
            //if (!_context.IsAttached(activityLogType))
            //    _context.ActivityLogTypes.Attach(activityLogType);
            //_context.DeleteObject(activityLogType);
            //_context.SaveChanges();

            //if (this.CacheEnabled)
            //    _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets all activity log type items
        /// </summary>
        /// <returns>Activity log type collection</returns>
        public List<ActivityLogType> GetAllActivityTypes()
        {
            //if (this.CacheEnabled)
            //{
            //    object cache = _cacheManager.Get(ACTIVITYTYPE_ALL_KEY);
            //    if (cache != null)
            //        return (List<ActivityLogType>)cache;
            //}

            
            //var query = from at in _context.ActivityLogTypes
            //            orderby at.Name
            //            select at;
            //var collection = query.ToList();

            //if (this.CacheEnabled)
            //    _cacheManager.Add(ACTIVITYTYPE_ALL_KEY, collection);
            
            //return collection;
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <returns>Activity log type item</returns>
        public ActivityLogType GetActivityTypeById(int activityLogTypeId)
        {
            //if (activityLogTypeId == 0)
            //    return null;

            //string key = string.Format(ACTIVITYTYPE_BY_ID_KEY, activityLogTypeId);
            //if (this.CacheEnabled)
            //{
            //    object cache = _cacheManager.Get(key);
            //    if (cache != null)
            //        return (ActivityLogType)cache;
            //}

            
            //var query = from at in _context.ActivityLogTypes
            //            where at.ActivityLogTypeId == activityLogTypeId
            //            select at;
            //var activityLogType = query.SingleOrDefault();

            //if (this.CacheEnabled)
            //    _cacheManager.Add(key, activityLogType);
            
            //return activityLogType;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(string systemKeyword, string comment)
        {
            return InsertActivity(systemKeyword, comment, new object[0]);
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(string systemKeyword, 
            string comment, params object[] commentParams)
        {
            //if (ShopContext.Current.User == null ||
            //    ShopContext.Current.User.IsGuest)
            //    return null;

            //var activityTypes = GetAllActivityTypes();
            //var activityType = activityTypes.FindBySystemKeyword(systemKeyword);
            //if (activityType == null || !activityType.Enabled)
            //    return null;

            //int customerId = ShopContext.Current.User.CustomerId;
            //comment = CommonHelper.EnsureNotNull(comment);
            //comment = string.Format(comment, commentParams);
            //comment = CommonHelper.EnsureMaximumLength(comment, 4000);

            

            //var activity = _context.ActivityLog.CreateObject();
            //activity.ActivityLogTypeId = activityType.ActivityLogTypeId;
            //activity.CustomerId = customerId;
            //activity.Comment = comment;
            //activity.CreatedOn = DateTime.UtcNow;

            //_context.ActivityLog.AddObject(activity);
            //_context.SaveChanges();

            //return activity;
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Deletes an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log type identifier</param>
        public void DeleteActivity(int activityLogId)
        {
            //var activity = GetActivityById(activityLogId);
            //if (activity == null)
            //    return;

            
            //if (!_context.IsAttached(activity))
            //    _context.ActivityLog.Attach(activity);
            //_context.DeleteObject(activity);
            //_context.SaveChanges();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all activity log items
        /// </summary>
        /// <param name="createdOnFrom">Log item creation from; null to load all customers</param>
        /// <param name="createdOnTo">Log item creation to; null to load all customers</param>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Activity log collection</returns>
        public PagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom,
            DateTime? createdOnTo, string email, string username, int activityLogTypeId,
            int pageIndex, int pageSize)
        {
            //var query = from al in _context.ActivityLog
            //            where (!createdOnFrom.HasValue || createdOnFrom.Value <= al.CreatedOn) &&
            //            (!createdOnTo.HasValue || createdOnTo.Value >= al.CreatedOn) &&
            //            (activityLogTypeId == 0 || activityLogTypeId == al.ActivityLogTypeId) &&
            //            (String.IsNullOrEmpty(email) || al.NpCustomer.Email.Contains(email)) &&
            //            (String.IsNullOrEmpty(username) || al.NpCustomer.Username.Contains(username)) &&
            //            !al.NpCustomer.IsGuest &&
            //            !al.NpCustomer.Deleted
            //            orderby al.CreatedOn descending
            //            select al;
            //var activityLog = new PagedList<ActivityLog>(query, pageIndex, pageSize);
            //return activityLog;
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log identifier</param>
        /// <returns>Activity log item</returns>
        public ActivityLog GetActivityById(int activityLogId)
        {
            //if (activityLogId == 0)
            //    return null;

            
            //var query = from al in _context.ActivityLog
            //            where al.ActivityLogId == activityLogId
            //            select al;
            //var activityLog = query.SingleOrDefault();
            //return activityLog;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears activity log
        /// </summary>
        public void ClearAllActivities()
        {
            
            //var activityLog = _context.ActivityLog.ToList();
            //foreach (var activityLogItem in activityLog)
            //    _context.DeleteObject(activityLogItem);
            //_context.SaveChanges();
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CustomerActivityManager.CacheEnabled");
            }
        }
        #endregion
    }
}
