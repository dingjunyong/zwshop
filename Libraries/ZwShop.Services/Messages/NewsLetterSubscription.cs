using System;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.Messages
{
    public class NewsLetterSubscription : BaseEntity
    {
        #region Properties
        
       

        public Guid NewsLetterSubscriptionGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subcriber email
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is active
        /// </summary>
        public bool Active
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time when subscription was created
        /// </summary>
        public DateTime CreatedOn
        {
            get;
            set;
        }
        #endregion

        #region Custom Properties
        
        /// <summary>
        /// Gets the customer associated with email
        /// </summary>
        public Customer Customer
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerByEmail(Email);
            }
        }

        #endregion
    }
}
