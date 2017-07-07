using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Data;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Orders;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Payment
{
    /// <summary>
    /// Payment service
    /// </summary>
    public partial class PaymentService : IPaymentService
    {
        #region Constants
        private const string CREDITCARDS_ALL_KEY = "Shop.creditcard.all";
        private const string CREDITCARDS_BY_ID_KEY = "Shop.creditcard.id-{0}";
        private const string CREDITCARDS_PATTERN_KEY = "Shop.creditcard.";

        private const string PAYMENTMETHODS_BY_ID_KEY = "Shop.paymentmethod.id-{0}";
        private const string PAYMENTMETHODS_PATTERN_KEY = "Shop.paymentmethod.";

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
        public PaymentService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion

 
        #region Properties
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.PaymentManager.CacheEnabled");
            }
        }
        #endregion

        public void DeletePaymentMethod(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetPaymentMethodById(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetPaymentMethodBySystemKeyword(string systemKeyword)
        {
            throw new NotImplementedException();
        }

        public List<PaymentMethod> GetAllPaymentMethods()
        {
            throw new NotImplementedException();
        }

        public List<PaymentMethod> GetAllPaymentMethods(int? filterByCountryId)
        {
            throw new NotImplementedException();
        }

        public List<PaymentMethod> GetAllPaymentMethods(int? filterByCountryId, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public void InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void CreatePaymentMethodCountryMapping(int paymentMethodId, int countryId)
        {
            throw new NotImplementedException();
        }

        public bool DoesPaymentMethodCountryMappingExist(int paymentMethodId, int countryId)
        {
            throw new NotImplementedException();
        }

        public void DeletePaymentMethodCountryMapping(int paymentMethodId, int countryId)
        {
            throw new NotImplementedException();
        }

        public void ProcessPayment(PaymentInfo paymentInfo, Customer customer, Guid orderGuid, ref ProcessPaymentResult processPaymentResult)
        {
            throw new NotImplementedException();
        }

        public string PostProcessPayment(Order order)
        {
            throw new NotImplementedException();
        }

        public decimal GetAdditionalHandlingFee(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public bool CanCapture(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public void Capture(Order order, ref ProcessPaymentResult processPaymentResult)
        {
            throw new NotImplementedException();
        }

        public bool CanPartiallyRefund(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public bool CanRefund(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public void Refund(Order order, ref CancelPaymentResult cancelPaymentResult)
        {
            throw new NotImplementedException();
        }

        public bool CanVoid(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public void Void(Order order, ref CancelPaymentResult cancelPaymentResult)
        {
            throw new NotImplementedException();
        }

        public PaymentMethodTypeEnum GetPaymentMethodType(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public void ProcessRecurringPayment(PaymentInfo paymentInfo, Customer customer, Guid orderGuid, ref ProcessPaymentResult processPaymentResult)
        {
            throw new NotImplementedException();
        }

        public void CancelRecurringPayment(Order order, ref CancelPaymentResult cancelPaymentResult)
        {
            throw new NotImplementedException();
        }

        public string GetMaskedCreditCardNumber(string creditCardNumber)
        {
            throw new NotImplementedException();
        }
    }
}
