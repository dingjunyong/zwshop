
using System.Collections.Generic;

namespace ZwShop.Services.Security
{
    /// <summary>
    /// IP Blacklist service interface
    /// </summary>
    public partial interface IBlacklistService
    {
        /// <summary>
        /// Gets an IP address by its identifier
        /// </summary>
        /// <param name="ipAddressId">IP Address unique identifier</param>
        /// <returns>An IP address</returns>
        BannedIpAddress GetBannedIpAddressById(int ipAddressId);

        /// <summary>
        /// Gets all IP addresses
        /// </summary>
        /// <returns>An IP address collection</returns>
        List<BannedIpAddress> GetBannedIpAddressAll();

        /// <summary>
        /// Inserts an IP address
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>IP Address</returns>
        void InsertBannedIpAddress(BannedIpAddress ipAddress);

        /// <summary>
        /// Updates an IP address
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>IP address</returns>
        void UpdateBannedIpAddress(BannedIpAddress ipAddress);

        /// <summary>
        /// Deletes an IP address by its identifier
        /// </summary>
        /// <param name="ipAddressId">IP address unique identifier</param>
        void DeleteBannedIpAddress(int ipAddressId);

        /// <summary>
        /// Gets an IP network by its Id
        /// </summary>
        /// <param name="bannedIpNetworkId">IP network unique identifier</param>
        /// <returns>IP network</returns>
        BannedIpNetwork GetBannedIpNetworkById(int bannedIpNetworkId);

        /// <summary>
        /// Gets all IP networks
        /// </summary>
        /// <returns>IP network collection</returns>
        List<BannedIpNetwork> GetBannedIpNetworkAll();

        /// <summary>
        /// Inserts an IP network
        /// </summary>
        /// <param name="ipNetwork">IP network</param>
        void InsertBannedIpNetwork(BannedIpNetwork ipNetwork);

        /// <summary>
        /// Updates an IP network
        /// </summary>
        /// <param name="ipNetwork">IP network</param>
        void UpdateBannedIpNetwork(BannedIpNetwork ipNetwork);

        /// <summary>
        /// Deletes an IP network
        /// </summary>
        /// <param name="bannedIpNetwork">IP network unique identifier</param>
        void DeleteBannedIpNetwork(int bannedIpNetwork);

        /// <summary>
        /// Checks if an IP from the IpAddressCollection or the IpNetworkCollection is banned
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>False or true</returns>
        bool IsIpAddressBanned(BannedIpAddress ipAddress);

        /// <summary>
        /// Check if the ip is valid.
        /// </summary>
        /// <param name="ipAddress">The string representation of an IP address</param>
        /// <returns>True if the IP is valid.</returns>
        bool IsValidIp(string ipAddress);
    }
}
