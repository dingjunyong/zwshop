using System;
using System.Collections.Generic;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Payment;
using ZwShop.Services.Shipping;
using ZwShop.Common;

namespace ZwShop.Services.Orders
{
    public partial interface IOrderService
    {
        #region Orders

        Order GetOrderById(int orderId);

        Order GetOrderByGuid(Guid orderGuid);

        void MarkOrderAsDeleted(int orderId);

        List<Order> SearchOrders(DateTime? startTime, DateTime? endTime,
            string customerEmail, OrderStatusEnum? os, PaymentStatusEnum? ps,
            ShippingStatusEnum? ss);

        List<Order> SearchOrders(DateTime? startTime, DateTime? endTime,
            string customerEmail, OrderStatusEnum? os, PaymentStatusEnum? ps,
            ShippingStatusEnum? ss, string orderGuid);

        List<Order> LoadAllOrders();

        List<Order> GetOrdersByCustomerId(int customerId);

        Order GetOrderByAuthorizationTransactionIdAndPaymentMethodId(string authorizationTransactionId,
            int paymentMethodId);

        List<Order> GetOrdersByAffiliateId(int affiliateId);

        void InsertOrder(Order order);

        void UpdateOrder(Order order);

        #endregion

        #region Reward points

        void DeleteRewardPointsHistory(int rewardPointsHistoryId);

        RewardPointsHistory GetRewardPointsHistoryById(int rewardPointsHistoryId);
        
        PagedList<RewardPointsHistory> GetAllRewardPointsHistoryEntries(int? customerId,
            int? orderId, int pageIndex, int pageSize);

        RewardPointsHistory InsertRewardPointsHistory(int customerId,
            int orderId, int points, decimal usedAmount,
            decimal usedAmountInCustomerCurrency, string customerCurrencyCode,
            string message, DateTime createdOn);

        void UpdateRewardPointsHistory(RewardPointsHistory rewardPointsHistory);

        #endregion




        #region Properties


        /// <summary>
        /// Gets or sets a value indicating whether Reward Points Program is enabled
        /// </summary>
        bool RewardPointsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Reward Points exchange rate
        /// </summary>
        decimal RewardPointsExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for registration
        /// </summary>
        int RewardPointsForRegistration { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for purchases (amount in primary store currency)
        /// </summary>
        decimal RewardPointsForPurchases_Amount { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for purchases
        /// </summary>
        int RewardPointsForPurchases_Points { get; set; }

        /// <summary>
        /// Points are awarded when the order status is
        /// </summary>
        OrderStatusEnum RewardPointsForPurchases_Awarded { get; set; }

        /// <summary>
        /// Points are canceled when the order is
        /// </summary>
        OrderStatusEnum RewardPointsForPurchases_Canceled { get; set; }


        /// <summary>
        /// Gets or sets a minimum order subtotal amount
        /// </summary>
        decimal MinOrderSubtotalAmount { get; set; }

        /// <summary>
        /// Gets or sets a minimum order total amount
        /// </summary>
        decimal MinOrderTotalAmount { get; set; }

        #endregion
    }
}