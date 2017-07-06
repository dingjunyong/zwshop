namespace ZwShop.Services.CustomerManagement
{
    public partial class CustomerAttribute : BaseEntity
    {
        #region Properties

        public int CustomerId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
        #endregion 

        #region Navigation Properties

        public virtual Customer NpCustomer { get; set; }

        #endregion
    }

}
