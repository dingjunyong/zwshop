namespace ZwShop.Services.CustomerManagement
{
    public enum CustomerRegistrationTypeEnum : int
    {
        /// <summary>
        /// 普通账户注册
        /// </summary>
        Standard = 1,
        /// <summary>
        /// 邮箱认证注册
        /// </summary>
        EmailValidation = 2,
        /// <summary>
        /// 管理员注册
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// 不允许注册 
        /// </summary>
        Disabled = 4,
    }
}
