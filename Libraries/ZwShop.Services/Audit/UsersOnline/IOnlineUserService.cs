using System.Collections.Generic;

namespace ZwShop.Services.Audit.UsersOnline
{
    /// <summary>
    /// Online user service interface
    /// </summary>
    public interface IOnlineUserService
    {
        /// <summary>
        /// Tracks current user
        /// </summary>
        void TrackCurrentUser();

        /// <summary>
        /// Clears user list
        /// </summary>
        void ClearUserList();

        /// <summary>
        /// Purges expired users
        /// </summary>
        void PurgeUsers();

        /// <summary>
        /// Get online users (guest)
        /// </summary>
        /// <returns>Online user list</returns>
        List<OnlineUserInfo> GetGuestList();

        /// <summary>
        /// Get online users (registered)
        /// </summary>
        /// <returns>Online user list</returns>
        List<OnlineUserInfo> GetRegisteredUsersOnline();

        /// <summary>
        /// Get online users (guests and registered users)
        /// </summary>
        /// <returns>Online user list</returns>
        List<OnlineUserInfo> GetAllUserList();
        
        /// <summary>
        /// Gets a value indicating whether tracking online users is enabled
        /// </summary>
        bool Enabled { get; set; }
        
        /// <summary>
        /// Gets a maximum online customer number
        /// </summary>
        int MaximumOnlineCustomers { get; set; }
    }
}