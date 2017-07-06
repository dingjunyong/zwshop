using System;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.CustomerManagement
{
    public partial class CustomerSession
    {
        #region Fields
        private Customer _customer;
        #endregion 

        #region Properties

        public Guid CustomerSessionGuid { get; set; }

        public int CustomerId { get; set; }

        public DateTime LastAccessed { get; set; }

        public bool IsExpired { get; set; }
        #endregion

        #region Custom Properties
        public Customer Customer
        {
            get
            {
                if (_customer == null)
                    _customer = IoC.Resolve<ICustomerService>().GetCustomerById(this.CustomerId);
                return _customer;
            }
        }
        #endregion
    }

}
