using System;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.CustomerManagement
{
    /// <summary>
    /// µÿ÷∑
    /// </summary>
    public partial class Address : BaseEntity
    {
        #region Properties

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public int StateProvinceId { get; set; }

        public string ZipPostalCode { get; set; }

        public int CountryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        #endregion 

        #region Custom Properties
        public Customer Customer
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerById(this.CustomerId);
            }
        }
        public StateProvince StateProvince
        {
            get
            {
                return IoC.Resolve<IStateProvinceService>().GetStateProvinceById(this.StateProvinceId);
            }
        }

        public Country Country
        {
            get
            {
                return IoC.Resolve<ICountryService>().GetCountryById(this.CountryId);
            }
        }
        #endregion

        #region Navigation Properties

        public virtual Customer NpCustomer { get; set; }

        #endregion
    }

}
