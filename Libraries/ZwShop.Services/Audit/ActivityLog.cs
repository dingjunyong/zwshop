using System;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.Audit
{
    /// <summary>
    /// 用户活动日志记录
    /// </summary>
    public partial class ActivityLog : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the activity log type identifier
        /// </summary>
        public int ActivityLogTypeId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the activity comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOn { get; set; }
        #endregion

        #region Custom properties

        /// <summary>
        /// Gets the activity log type
        /// </summary>
        public ActivityLogType ActivityLogType
        {
            get
            {
                return IoC.Resolve<ICustomerActivityService>().GetActivityTypeById(this.ActivityLogTypeId);
            }
        }

        /// <summary>
        /// Gers the customer
        /// </summary>
        public Customer Customer
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerById(this.CustomerId);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the activity log type
        /// </summary>
        public virtual ActivityLogType NpActivityLogType { get; set; }

        /// <summary>
        /// Gets the customer
        /// </summary>
        public virtual Customer NpCustomer { get; set; }
        
        #endregion
    }
}
