using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;
using ZwShop.Services.Messages;
using ZwShop.Services.Orders;
using ZwShop.Services.Payment;
using ZwShop.Services.Shipping; 

namespace ZwShop.Services.CustomerManagement
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer : BaseEntity
    {
        #region Fields

        private List<CustomerAttribute> _customerAttributesCache;
        private List<CustomerRole> _customerRolesCache;
        private Address _billingAddressCache;
        private Address _shippingAddressCache;
        private List<RewardPointsHistory> _rewardPointsHistoryCache;

        #endregion

        #region Methods

        /// <summary>
        /// Resets cached values for an instance
        /// </summary>
        public void ResetCachedValues()
        {
            _customerAttributesCache = null;
            _customerRolesCache = null;
            _billingAddressCache = null;
            _shippingAddressCache = null;
            _rewardPointsHistoryCache = null;
        }

        #endregion

        #region Properties

        public Guid CustomerGuid { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public string SaltKey { get; set; }

        /// <summary>
        /// 默认运送地址
        /// </summary>
        public int ShippingAddressId { get; set; }

        
        public int LastPaymentMethodId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is administrator
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is guest
        /// </summary>
        public bool IsGuest { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signature { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int AvatarId { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        #endregion

        #region Custom Properties

      

        /// <summary>
        /// Gets the customer attributes
        /// </summary>
        public List<CustomerAttribute> CustomerAttributes
        {
            get
            {
                if (_customerAttributesCache == null)
                    _customerAttributesCache = IoC.Resolve<ICustomerService>().GetCustomerAttributesByCustomerId(this.Id);

                return _customerAttributesCache;
            }
        }

        /// <summary>
        /// Gets the customer roles
        /// </summary>
        public List<CustomerRole> CustomerRoles
        {
            get
            {
                if (_customerRolesCache == null)
                    _customerRolesCache = IoC.Resolve<ICustomerService>().GetCustomerRolesByCustomerId(this.Id);

                return _customerRolesCache;
            }
        }

      

        /// <summary>
        /// Gets the last shipping address
        /// </summary>
        public Address ShippingAddress
        {
            get
            {
                if (_shippingAddressCache == null)
                    _shippingAddressCache = IoC.Resolve<ICustomerService>().GetAddressById(this.ShippingAddressId);

                return _shippingAddressCache;
            }
        }


 

        /// <summary>
        /// Gets the shipping addresses
        /// </summary>
        public List<Address> ShippingAddresses
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetAddressesByCustomerId(this.Id, false);
            }
        }

        /// <summary>
        /// Gets the orders
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                return IoC.Resolve<IOrderService>().GetOrdersByCustomerId(this.Id);
            }
        }

    

        /// <summary>
        /// Gets the avatar
        /// </summary>
        public Picture Avatar
        {
            get
            {
                return IoC.Resolve<IPictureService>().GetPictureById(this.AvatarId);
            }
        }

        /// <summary>
        /// Gets the last payment method
        /// </summary>
        public PaymentMethod LastPaymentMethod
        {
            get
            {
                return IoC.Resolve<IPaymentService>().GetPaymentMethodById(this.LastPaymentMethodId);
            }
        }

        /// <summary>
        /// Gets the customer full name
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(this.FirstName))
                    return this.LastName;
                else
                    return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the gender
        /// </summary>
        public string Gender
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute genderAttr = customerAttributes.FindAttribute("Gender", this.Id);
                if (genderAttr != null)
                    return genderAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute genderAttr = customerAttributes.FindAttribute("Gender", this.Id);
                if (genderAttr != null)
                {
                    genderAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(genderAttr);
                }
                else
                {
                    genderAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "Gender",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(genderAttr);
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute firstNameAttr = customerAttributes.FindAttribute("FirstName", this.Id);
                if (firstNameAttr != null)
                    return firstNameAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute firstNameAttr = customerAttributes.FindAttribute("FirstName", this.Id);
                if (firstNameAttr != null)
                {
                    firstNameAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(firstNameAttr);
                }
                else
                {
                    firstNameAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "FirstName",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(firstNameAttr);
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute lastNameAttr = customerAttributes.FindAttribute("LastName", this.Id);
                if (lastNameAttr != null)
                    return lastNameAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute lastNameAttr = customerAttributes.FindAttribute("LastName", this.Id);
                if (lastNameAttr != null)
                {
                    lastNameAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(lastNameAttr);
                }
                else
                {
                    lastNameAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "LastName",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(lastNameAttr);
                }

                ResetCachedValues();
            }
        }
        
        /// <summary>
        /// Gets or sets the company
        /// </summary>
        public string Company
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute companyAttr = customerAttributes.FindAttribute("Company", this.Id);
                if (companyAttr != null)
                    return companyAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute companyAttr = customerAttributes.FindAttribute("Company", this.Id);
                if (companyAttr != null)
                {
                    companyAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(companyAttr);
                }
                else
                {
                    companyAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "Company",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(companyAttr);
                }
                
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the VAT number (the European Union Value Added Tax)
        /// </summary>
        public string VatNumber
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute vatNumberAttr = customerAttributes.FindAttribute("VatNumber", this.Id);
                if (vatNumberAttr != null)
                    return vatNumberAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute vatNumberAttr = customerAttributes.FindAttribute("VatNumber", this.Id);
                if (vatNumberAttr != null)
                {
                    vatNumberAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(vatNumberAttr);
                }
                else
                {
                    vatNumberAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "VatNumber",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(vatNumberAttr);
                }
                
                ResetCachedValues();
            }
        }


        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string StreetAddress
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute streetAddressAttr = customerAttributes.FindAttribute("StreetAddress", this.Id);
                if (streetAddressAttr != null)
                    return streetAddressAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute streetAddressAttr = customerAttributes.FindAttribute("StreetAddress", this.Id);
                if (streetAddressAttr != null)
                {
                    streetAddressAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(streetAddressAttr);
                }
                else
                {
                    streetAddressAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "StreetAddress",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(streetAddressAttr);
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the street address 2
        /// </summary>
        public string StreetAddress2
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute streetAddress2Attr = customerAttributes.FindAttribute("StreetAddress2", this.Id);
                if (streetAddress2Attr != null)
                    return streetAddress2Attr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute streetAddress2Attr = customerAttributes.FindAttribute("StreetAddress2", this.Id);
                if (streetAddress2Attr != null)
                {
                    streetAddress2Attr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(streetAddress2Attr);
                }
                else
                {
                    streetAddress2Attr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "StreetAddress2",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(streetAddress2Attr);
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the zip/postal code
        /// </summary>
        public string ZipPostalCode
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute zipPostalCodeAttr = customerAttributes.FindAttribute("ZipPostalCode", this.Id);
                if (zipPostalCodeAttr != null)
                    return zipPostalCodeAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute zipPostalCodeAttr = customerAttributes.FindAttribute("ZipPostalCode", this.Id);
                if (zipPostalCodeAttr != null)
                {
                    zipPostalCodeAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(zipPostalCodeAttr);
                }
                else
                {
                    zipPostalCodeAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "ZipPostalCode",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(zipPostalCodeAttr);
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute cityAttr = customerAttributes.FindAttribute("City", this.Id);
                if (cityAttr != null)
                    return cityAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                value = value.Trim();

                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute cityAttr = customerAttributes.FindAttribute("City", this.Id);
                if (cityAttr != null)
                {
                    cityAttr.Value = value;
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(cityAttr);
                }
                else
                {
                    cityAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "City",
                        Value = value
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(cityAttr);
                }

                ResetCachedValues();
            }
        }



        /// <summary>
        /// Gets or sets the state/province identifier
        /// </summary>
        public int StateProvinceId
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute stateProvinceIdAttr = customerAttributes.FindAttribute("StateProvinceId", this.Id);
                if (stateProvinceIdAttr != null)
                {
                    int stateProvinceId = 0;
                    int.TryParse(stateProvinceIdAttr.Value, out stateProvinceId);
                    return stateProvinceId;
                }
                else
                    return 0;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute stateProvinceIdAttr = customerAttributes.FindAttribute("StateProvinceId", this.Id);
                if (stateProvinceIdAttr != null)
                {
                    stateProvinceIdAttr.Value = value.ToString();
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(stateProvinceIdAttr);
                }
                else
                {
                    stateProvinceIdAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "StateProvinceId",
                        Value = value.ToString()
                    };
                   IoC.Resolve<ICustomerService>().InsertCustomerAttribute(stateProvinceIdAttr);
                }

                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets the value indivating whether customer is agree to receive newsletters
        /// </summary>
        public bool ReceiveNewsletter
        {
            get
            {
                NewsLetterSubscription subscription = this.NewsLetterSubscription;

                return (subscription != null && subscription.Active);
            }
            set
            {
                NewsLetterSubscription subscription = this.NewsLetterSubscription;
                if (subscription != null)
                {
                    if (value)
                    {
                        subscription.Active = true;
                        IoC.Resolve<IMessageService>().UpdateNewsLetterSubscription(subscription);
                    }
                    else
                    {
                        IoC.Resolve<IMessageService>().DeleteNewsLetterSubscription(subscription.Id);
                    }
                }
                else
                {
                    if (value)
                    {
                        var newsLetterSubscription = new NewsLetterSubscription()
                        {
                            NewsLetterSubscriptionGuid = Guid.NewGuid(),
                            Email = Email,
                            Active = value,
                            CreatedOn = DateTime.UtcNow
                        };
                        IoC.Resolve<IMessageService>().InsertNewsLetterSubscription(newsLetterSubscription);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the NewsLetterSubscription entity if the customer has been subscribed to newsletters
        /// </summary>
        public NewsLetterSubscription NewsLetterSubscription
        {
            get
            {
                return IoC.Resolve<IMessageService>().GetNewsLetterSubscriptionByEmail(Email);
            }
        }

        /// <summary>
        /// Gets or sets the password recovery token
        /// </summary>
        public string PasswordRecoveryToken
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute passwordRecoveryAttr = customerAttributes.FindAttribute("PasswordRecoveryToken", this.Id);
                if (passwordRecoveryAttr != null)
                    return passwordRecoveryAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute passwordRecoveryAttr = customerAttributes.FindAttribute("PasswordRecoveryToken", this.Id);

                if (passwordRecoveryAttr != null)
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        passwordRecoveryAttr.Value = value;
                        IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(passwordRecoveryAttr);
                    }
                    else
                    {
                        IoC.Resolve<ICustomerService>().DeleteCustomerAttribute(passwordRecoveryAttr.Id);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        passwordRecoveryAttr = new CustomerAttribute()
                        {
                            CustomerId = this.Id,
                            Key = "PasswordRecoveryToken",
                            Value = value
                        };
                        IoC.Resolve<ICustomerService>().InsertCustomerAttribute(passwordRecoveryAttr);
                    }
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the account activation token
        /// </summary>
        public string AccountActivationToken
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute accountActivationAttr = customerAttributes.FindAttribute("AccountActivationToken", this.Id);
                if (accountActivationAttr != null)
                    return accountActivationAttr.Value;
                else
                    return string.Empty;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute accountActivationAttr = customerAttributes.FindAttribute("AccountActivationToken", this.Id);

                if (accountActivationAttr != null)
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        accountActivationAttr.Value = value;
                        IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(accountActivationAttr);
                    }
                    else
                    {
                        IoC.Resolve<ICustomerService>().DeleteCustomerAttribute(accountActivationAttr.Id);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        accountActivationAttr = new CustomerAttribute()
                        {
                            CustomerId = this.Id,
                            Key = "AccountActivationToken",
                            Value = value
                        };
                        IoC.Resolve<ICustomerService>().InsertCustomerAttribute(accountActivationAttr);
                    }
                }
                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets reward points collection
        /// </summary>
        public List<RewardPointsHistory> RewardPointsHistory
        {
            get
            {
                if (this.Id == 0)
                    return new List<RewardPointsHistory>();
                if (_rewardPointsHistoryCache == null)
                {
                    _rewardPointsHistoryCache = IoC.Resolve<IOrderService>().GetAllRewardPointsHistoryEntries(this.Id,
                        null, 0, int.MaxValue);
                }
                return _rewardPointsHistoryCache;
            }
        }

        /// <summary>
        /// Gets reward points balance
        /// </summary>
        public int RewardPointsBalance
        {
            get
            {
                int result = 0;
                if (this.RewardPointsHistory.Count > 0)
                    result = this.RewardPointsHistory[0].PointsBalance;
                return result;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use reward points during checkout
        /// </summary>
        public bool UseRewardPointsDuringCheckout
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute useRewardPointsAttr = customerAttributes.FindAttribute("UseRewardPointsDuringCheckout", this.Id);
                if (useRewardPointsAttr != null)
                {
                    bool useRewardPoints = false;
                    bool.TryParse(useRewardPointsAttr.Value, out useRewardPoints);
                    return useRewardPoints;
                }
                else
                    return false;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute useRewardPointsAttr = customerAttributes.FindAttribute("UseRewardPointsDuringCheckout", this.Id);
                if (useRewardPointsAttr != null)
                {
                    useRewardPointsAttr.Value = value.ToString();
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(useRewardPointsAttr);
                }
                else
                {
                    useRewardPointsAttr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "UseRewardPointsDuringCheckout",
                        Value = value.ToString()
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(useRewardPointsAttr);
                }

                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customer is notified about new private messages
        /// </summary>
        public bool NotifiedAboutNewPrivateMessages
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute attr = customerAttributes.FindAttribute("NotifiedAboutNewPrivateMessages", this.Id);
                if (attr != null)
                {
                    bool result = false;
                    bool.TryParse(attr.Value, out result);
                    return result;
                }
                else
                    return false;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute attr = customerAttributes.FindAttribute("NotifiedAboutNewPrivateMessages", this.Id);
                if (attr != null)
                {
                    attr.Value = value.ToString();
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(attr);
                }
                else
                {
                    attr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "NotifiedAboutNewPrivateMessages",
                        Value = value.ToString()
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(attr);
                }

                ResetCachedValues();
            }
        }

        /// <summary>
        /// Gets or sets the impersonated customer identifier
        /// </summary>
        public Guid ImpersonatedCustomerGuid
        {
            get
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute attr = customerAttributes.FindAttribute("ImpersonatedCustomerGuid", this.Id);
                if (attr != null)
                {
                    Guid _impersonatedCustomerGuid = Guid.Empty;
                    Guid.TryParse(attr.Value, out _impersonatedCustomerGuid);
                    return _impersonatedCustomerGuid;
                }
                else
                    return Guid.Empty;
            }
            set
            {
                var customerAttributes = this.CustomerAttributes;
                CustomerAttribute attr = customerAttributes.FindAttribute("ImpersonatedCustomerGuid", this.Id);
                if (attr != null)
                {
                    attr.Value = value.ToString();
                    IoC.Resolve<ICustomerService>().UpdateCustomerAttribute(attr);
                }
                else
                {
                    attr = new CustomerAttribute()
                    {
                        CustomerId = this.Id,
                        Key = "ImpersonatedCustomerGuid",
                        Value = value.ToString()
                    };
                    IoC.Resolve<ICustomerService>().InsertCustomerAttribute(attr);
                }
                ResetCachedValues();
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the customer roles
        /// </summary>
        public virtual ICollection<CustomerRole> NpCustomerRoles { get; set; }   
        
        /// <summary>
        /// Gets the reward points usage history
        /// </summary>
        public virtual ICollection<RewardPointsHistory> NpRewardPointsHistory { get; set; }
        
        #endregion
    }
}