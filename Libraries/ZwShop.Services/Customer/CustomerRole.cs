using System.Collections.Generic;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.CustomerManagement
{
    public partial class CustomerRole : BaseEntity
    {
        #region Properties

      
        public string Name { get; set; }

        
        public bool Active { get; set; }


        public bool Deleted { get; set; }

        #endregion

        #region Custom Properties

        /// <summary>
        /// Gets the customers of the role
        /// </summary>
        public List<Customer> Customers
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomersByCustomerRoleId(this.Id);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the customers
        /// </summary>
        public virtual ICollection<Customer> NpCustomers { get; set; }
        
        #endregion
    }

}