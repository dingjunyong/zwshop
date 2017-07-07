
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ZwShop.Services.Audit;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Data; 
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Messages;
using ZwShop.Services.Messages.SMS;
using ZwShop.Services.Payment;
using ZwShop.Services.Products;
using ZwShop.Services.Profile;
using ZwShop.Services.Security;
using ZwShop.Services.Shipping;
using ZwShop.Common;
using ZwShop.Common.Utils;
using ZwShop.Common.Utils.Html;

namespace ZwShop.Services.Orders
{
    /// <summary>
    /// Order service
    /// </summary>
    public partial class OrderService : IOrderService
    {
        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache service
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public OrderService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion





        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByGuid(Guid orderGuid)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderAsDeleted(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> SearchOrders(DateTime? startTime, DateTime? endTime, string customerEmail, OrderStatusEnum? os, PaymentStatusEnum? ps, ShippingStatusEnum? ss)
        {
            throw new NotImplementedException();
        }

        public List<Order> SearchOrders(DateTime? startTime, DateTime? endTime, string customerEmail, OrderStatusEnum? os, PaymentStatusEnum? ps, ShippingStatusEnum? ss, string orderGuid)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByAuthorizationTransactionIdAndPaymentMethodId(string authorizationTransactionId, int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByAffiliateId(int affiliateId)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public OrderProductVariant GetOrderProductVariantById(int orderProductVariantId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderProductVariant(int orderProductVariantId)
        {
            throw new NotImplementedException();
        }

        public OrderProductVariant GetOrderProductVariantByGuid(Guid orderProductVariantGuid)
        {
            throw new NotImplementedException();
        }

        public List<OrderProductVariant> GetAllOrderProductVariants(int? orderId, int? customerId, DateTime? startTime, DateTime? endTime, OrderStatusEnum? os, PaymentStatusEnum? ps, ShippingStatusEnum? ss)
        {
            throw new NotImplementedException();
        }

        public List<OrderProductVariant> GetAllOrderProductVariants(int? orderId, int? customerId, DateTime? startTime, DateTime? endTime, OrderStatusEnum? os, PaymentStatusEnum? ps, ShippingStatusEnum? ss, bool loadDownloableProductsOnly)
        {
            throw new NotImplementedException();
        }

        public List<OrderProductVariant> GetOrderProductVariantsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public void InsertOrderProductVariant(OrderProductVariant opv)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderProductVariant(OrderProductVariant opv)
        {
            throw new NotImplementedException();
        }

        public OrderNote GetOrderNoteById(int orderNoteId)
        {
            throw new NotImplementedException();
        }

        public List<OrderNote> GetOrderNoteByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderNote> GetOrderNoteByOrderId(int orderId, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderNote(int orderNoteId)
        {
            throw new NotImplementedException();
        }

        public OrderNote InsertOrderNote(int orderId, string note, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public OrderNote InsertOrderNote(int orderId, string note, bool displayToCustomer, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderNote(OrderNote orderNote)
        {
            throw new NotImplementedException();
        }

        public void DeleteRewardPointsHistory(int rewardPointsHistoryId)
        {
            throw new NotImplementedException();
        }

        public RewardPointsHistory GetRewardPointsHistoryById(int rewardPointsHistoryId)
        {
            throw new NotImplementedException();
        }

        public PagedList<RewardPointsHistory> GetAllRewardPointsHistoryEntries(int? customerId, int? orderId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public RewardPointsHistory InsertRewardPointsHistory(int customerId, int orderId, int points, decimal usedAmount, decimal usedAmountInCustomerCurrency, string customerCurrencyCode, string message, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public void UpdateRewardPointsHistory(RewardPointsHistory rewardPointsHistory)
        {
            throw new NotImplementedException();
        }

        public bool RewardPointsEnabled
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

        public decimal RewardPointsExchangeRate
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

        public int RewardPointsForRegistration
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

        public decimal RewardPointsForPurchases_Amount
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

        public int RewardPointsForPurchases_Points
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

        public OrderStatusEnum RewardPointsForPurchases_Awarded
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

        public OrderStatusEnum RewardPointsForPurchases_Canceled
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

        public decimal MinOrderSubtotalAmount
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

        public decimal MinOrderTotalAmount
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
