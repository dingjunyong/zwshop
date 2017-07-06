using System;

namespace ZwShop.Services.Security
{
    /// <summary>
    /// Network IP address implementation
    /// </summary>
    public partial class BannedIpAddress : BaseEntity
    {
        /// <summary>
        /// Gets or sets the IP address unique identifier
        /// </summary>
        public int BannedIpAddressId { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a reason why the IP was banned
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets when the IP address record was banned
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets when the banned IP address record was last updated
        /// </summary>
        public DateTime UpdatedOn { get; set; }
    }
}
