using System;

namespace ZwShop.Services.Security
{
    /// <summary>
    /// Network IP address range implementation
    /// </summary>
    public partial class BannedIpNetwork : BaseEntity
    {
        /// <summary>
        /// Gets or sets the IP address unique identifier
        /// </summary>
        public int BannedIpNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the starting IP address in the range
        /// </summary>
        public string StartAddress { get; set; }

        /// <summary>
        /// Gets or sets the ending IP address in the range
        /// </summary>
        public string EndAddress { get; set; }

        /// <summary>
        /// Gets or sets a reason why the IP network was banned
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets a list of exceptions in the IP Network
        /// </summary>
        public string IpException { get; set; }

        /// <summary>
        /// Gets or sets when the IP address record was banned
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets when the banned IP address record was last updated
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Returns the IP range as a formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}", StartAddress, EndAddress);
        }
    }
}
