using System;
using System.Collections.Generic;
using System.Web.Security;
using ZwShop.Services.Orders;
using ZwShop.Services.Payment;
using ZwShop.Services.Profile;
using ZwShop.Services.Shipping;
using ZwShop.Common;

namespace ZwShop.Services.CustomerManagement
{
    /// <summary>
    /// Customer service interface
    /// </summary>
    public partial interface ICustomerService
    {
        #region Addresses
        void DeleteAddress(int addressId);

        Address GetAddressById(int addressId);

        List<Address> GetAddressesByCustomerId(int customerId, bool getBillingAddresses);

        void InsertAddress(Address address);

        void UpdateAddress(Address address);

        bool CanUseAddressAsBillingAddress(Address address);

        bool CanUseAddressAsShippingAddress(Address address);

        #endregion

        #region Customers
        Customer SetEmail(int customerId, string newEmail);

        Customer ChangeCustomerUsername(int customerId, string newUsername);

        Customer SetCustomerSignature(int customerId, string signature);

        void CreateAnonymousUser();


        PagedList<Customer> GetAllCustomers();

        PagedList<Customer> GetAllCustomers(DateTime? registrationFrom,
            DateTime? registrationTo, string email, string username,
            bool dontLoadGuestCustomers, int pageSize, int pageIndex);

        PagedList<Customer> GetAllCustomers(DateTime? registrationFrom,
            DateTime? registrationTo, string email, string username,
            bool dontLoadGuestCustomers, int dateOfBirthMonth, int dateOfBirthDay,
            int pageSize, int pageIndex);

        List<Customer> GetCustomersByCustomerRoleId(int customerRoleId);

        void MarkCustomerAsDeleted(int customerId);

        Customer GetCustomerByEmail(string email);

        Customer GetCustomerByUsername(string username);

        Customer GetCustomerById(int customerId);

        Customer GetCustomerByGuid(Guid customerGuid);

        Customer AddCustomer(string email, string username, string password,
            bool isAdmin, bool isGuest, bool active, out MembershipCreateStatus status);

        Customer AddCustomer(Guid customerGuid, string email, string username,
            string password, 
            int shippingAddressId, int lastPaymentMethodId,
            bool isAdmin, bool isGuest,
            string signature,
            bool active, bool deleted, DateTime registrationDate,
            int avatarId, DateTime? dateOfBirth, out MembershipCreateStatus status);

        
        Customer AddCustomerForced(Guid customerGuid, string email,
            string username, string passwordHash, string saltKey,
            int shippingAddressId, int lastPaymentMethodId,
            bool isAdmin, bool isGuest,  string signature, 
            bool active, bool deleted, DateTime registrationDate, 
            int avatarId, DateTime? dateOfBirth);

       
        void UpdateCustomer(Customer customer);

      
        void ModifyPassword(string email, string oldPassword, string password);

     
        void ModifyPassword(string email, string newPassword);

        void ModifyPassword(int customerId, string newPassword);

        void Activate(Guid customerGuid);

        void Activate(int customerId);

        void Activate(int customerId, bool sendCustomerWelcomeMessage);

        void Deactivate(Guid customerGuid);

        void Deactivate(int customerId);

        bool Login(string email, string password);

        void Logout();

        #endregion

        #region Reports
        List<CustomerBestReportLine> GetBestCustomersReport(DateTime? startTime,
            DateTime? endTime, OrderStatusEnum? os, PaymentStatusEnum? ps,
            ShippingStatusEnum? ss, int orderBy);

        int GetRegisteredCustomersReport(int days);

        List<CustomerReportByAttributeKeyLine> GetCustomerReportByAttributeKey(string customerAttributeKey);

        #endregion

        #region Customer attributes
        void DeleteCustomerAttribute(int customerAttributeId);

        CustomerAttribute GetCustomerAttributeById(int customerAttributeId);

        List<CustomerAttribute> GetCustomerAttributesByCustomerId(int customerId);

        void InsertCustomerAttribute(CustomerAttribute customerAttribute);

        void UpdateCustomerAttribute(CustomerAttribute customerAttribute);

        #endregion

        #region Customer roles

        void MarkCustomerRoleAsDeleted(int customerRoleId);


        CustomerRole GetCustomerRoleById(int customerRoleId);

        List<CustomerRole> GetAllCustomerRoles();

        List<CustomerRole> GetCustomerRolesByCustomerId(int customerId);

        List<CustomerRole> GetCustomerRolesByCustomerId(int customerId, bool showHidden);

        void InsertCustomerRole(CustomerRole customerRole);

        void UpdateCustomerRole(CustomerRole customerRole);

        void AddCustomerToRole(int customerId, int customerRoleId);

        void RemoveCustomerFromRole(int customerId, int customerRoleId);

        #endregion

        #region Customer discount

        void AddDiscountToCustomerRole(int customerRoleId, int discountId);

        void RemoveDiscountFromCustomerRole(int customerRoleId, int discountId);

        List<CustomerRole> GetCustomerRolesByDiscountId(int discountId);

        #endregion

        #region Customer sessions

        CustomerSession GetCustomerSessionByGuid(Guid customerSessionGuid);

        CustomerSession GetCustomerSessionByCustomerId(int customerId);

        void DeleteCustomerSession(Guid customerSessionGuid);

        List<CustomerSession> GetAllCustomerSessions();

        List<CustomerSession> GetAllCustomerSessionsWithNonEmptyShoppingCart();

        void DeleteExpiredCustomerSessions(DateTime olderThan);

        CustomerSession SaveCustomerSession(Guid customerSessionGuid,
            int customerId, DateTime lastAccessed, bool isExpired);

        #endregion

        #region Properties

        bool AnonymousCheckoutAllowed { get; set; }

        bool UsernamesEnabled { get; set; }

        bool AllowCustomersToChangeUsernames { get; set; }

        bool AllowCustomersToUploadAvatars { get; set; }

        bool DefaultAvatarEnabled { get; set; }

        bool ShowCustomersLocation { get; set; }

        bool ShowCustomersJoinDate { get; set; }

        bool AllowViewingProfiles { get; set; }

        CustomerRegistrationTypeEnum CustomerRegistrationType { get; set; }

        bool AllowNavigationOnlyRegisteredCustomers { get; set; }

        bool NotifyNewCustomerRegistration { get; set; }
        #endregion
    }
}