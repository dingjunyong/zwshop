namespace ZwShop.Services.Audit
{
    public enum LogTypeEnum : int
    {
        /// <summary>
        /// 客户错误
        /// </summary>
        CustomerError = 1,
        /// <summary>
        /// 邮件发送错误
        /// </summary>
        MailError = 2,
        /// <summary>
        /// 订单错误
        /// </summary>
        OrderError = 3,
        /// <summary>
        /// 管理员错误
        /// </summary>
        AdministrationArea = 4,
        /// <summary>
        /// 公共错误
        /// </summary>
        CommonError = 5,
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown = 20,
    }
}
