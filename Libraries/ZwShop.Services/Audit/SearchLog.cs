

using System;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.Audit
{
    public partial class SearchLog : BaseEntity
    {
        #region Properties

        public string SearchTerm { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedOn { get; set; }

        #endregion 

        #region Custom Properties

        /// <summary>
        /// Gets the customer
        /// </summary>
        public Customer Customer
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerById(this.CustomerId);
            }
        }
        #endregion
    }

}
