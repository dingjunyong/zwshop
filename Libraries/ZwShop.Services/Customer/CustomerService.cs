

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Data;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Messages;
using ZwShop.Services.Orders;
using ZwShop.Services.Payment;
using ZwShop.Services.Profile;
using ZwShop.Services.Shipping;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.CustomerManagement
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : ICustomerService
    {
        #region Constants

        private const string CUSTOMERROLES_ALL_KEY = "Shop.customerrole.all-{0}";
        private const string CUSTOMERROLES_BY_ID_KEY = "Shop.customerrole.id-{0}";
        private const string CUSTOMERROLES_BY_DISCOUNTID_KEY = "Shop.customerrole.bydiscountid-{0}-{1}";
        private const string CUSTOMERROLES_PATTERN_KEY = "Shop.customerrole.";
        #endregion

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public CustomerService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion



        public void DeleteAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public Address GetAddressById(int addressId)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAddressesByCustomerId(int customerId, bool getBillingAddresses)
        {
            throw new NotImplementedException();
        }

        public void InsertAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public bool CanUseAddressAsBillingAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public bool CanUseAddressAsShippingAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Customer SetEmail(int customerId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public Customer ChangeCustomerUsername(int customerId, string newUsername)
        {
            throw new NotImplementedException();
        }

        public Customer SetCustomerSignature(int customerId, string signature)
        {
            throw new NotImplementedException();
        }

        public void CreateAnonymousUser()
        {
            throw new NotImplementedException();
        }

        public PagedList<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public PagedList<Customer> GetAllCustomers(DateTime? registrationFrom, DateTime? registrationTo, string email, string username, bool dontLoadGuestCustomers, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public PagedList<Customer> GetAllCustomers(DateTime? registrationFrom, DateTime? registrationTo, string email, string username, bool dontLoadGuestCustomers, int dateOfBirthMonth, int dateOfBirthDay, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersByCustomerRoleId(int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public void MarkCustomerAsDeleted(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByGuid(Guid customerGuid)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(string email, string username, string password, bool isAdmin, bool isGuest, bool active, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Guid customerGuid, string email, string username, string password, int shippingAddressId, int lastPaymentMethodId, bool isAdmin, bool isGuest, string signature, bool active, bool deleted, DateTime registrationDate, int avatarId, DateTime? dateOfBirth, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomerForced(Guid customerGuid, string email, string username, string passwordHash, string saltKey, int shippingAddressId, int lastPaymentMethodId, bool isAdmin, bool isGuest, string signature, bool active, bool deleted, DateTime registrationDate, int avatarId, DateTime? dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void ModifyPassword(string email, string oldPassword, string password)
        {
            throw new NotImplementedException();
        }

        public void ModifyPassword(string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void ModifyPassword(int customerId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Activate(Guid customerGuid)
        {
            throw new NotImplementedException();
        }

        public void Activate(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Activate(int customerId, bool sendCustomerWelcomeMessage)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(Guid customerGuid)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public List<CustomerBestReportLine> GetBestCustomersReport(DateTime? startTime, DateTime? endTime, OrderStatusEnum? os, PaymentStatusEnum? ps, ShippingStatusEnum? ss, int orderBy)
        {
            throw new NotImplementedException();
        }

        public int GetRegisteredCustomersReport(int days)
        {
            throw new NotImplementedException();
        }

        public List<CustomerReportByAttributeKeyLine> GetCustomerReportByAttributeKey(string customerAttributeKey)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerAttribute(int customerAttributeId)
        {
            throw new NotImplementedException();
        }

        public CustomerAttribute GetCustomerAttributeById(int customerAttributeId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerAttribute> GetCustomerAttributesByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomerAttribute(CustomerAttribute customerAttribute)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerAttribute(CustomerAttribute customerAttribute)
        {
            throw new NotImplementedException();
        }

        public void MarkCustomerRoleAsDeleted(int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerRole> GetAllCustomerRoles()
        {
            throw new NotImplementedException();
        }

        public List<CustomerRole> GetCustomerRolesByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerRole> GetCustomerRolesByCustomerId(int customerId, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomerRole(CustomerRole customerRole)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerToRole(int customerId, int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerFromRole(int customerId, int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public void AddDiscountToCustomerRole(int customerRoleId, int discountId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscountFromCustomerRole(int customerRoleId, int discountId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerRole> GetCustomerRolesByDiscountId(int discountId)
        {
            throw new NotImplementedException();
        }

        public CustomerSession GetCustomerSessionByGuid(Guid customerSessionGuid)
        {
            throw new NotImplementedException();
        }

        public CustomerSession GetCustomerSessionByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerSession(Guid customerSessionGuid)
        {
            throw new NotImplementedException();
        }

        public List<CustomerSession> GetAllCustomerSessions()
        {
            throw new NotImplementedException();
        }

        public List<CustomerSession> GetAllCustomerSessionsWithNonEmptyShoppingCart()
        {
            throw new NotImplementedException();
        }

        public void DeleteExpiredCustomerSessions(DateTime olderThan)
        {
            throw new NotImplementedException();
        }

        public CustomerSession SaveCustomerSession(Guid customerSessionGuid, int customerId, DateTime lastAccessed, bool isExpired)
        {
            throw new NotImplementedException();
        }

        public bool AnonymousCheckoutAllowed
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UsernamesEnabled
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AllowCustomersToChangeUsernames
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AllowCustomersToUploadAvatars
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DefaultAvatarEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ShowCustomersLocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ShowCustomersJoinDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AllowViewingProfiles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public CustomerRegistrationTypeEnum CustomerRegistrationType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AllowNavigationOnlyRegisteredCustomers
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool NotifyNewCustomerRegistration
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}