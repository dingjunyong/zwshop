using System;

namespace ZwShop.Services.Audit.UsersOnline
{
    /// <summary>
    /// 在线用户信息
    /// </summary>
    public partial class OnlineUserInfo
    {
        public Guid OnlineUserGuid { get; set; }

        public int? AssociatedCustomerId { get; set; }

        public string IPAddress { get; set; }

        public string LastPageVisited { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastVisit { get; set; }
    }
}
