using System;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Orders;

namespace ZwShop.Services.Payment
{
    /// <summary>
    /// Provides an interface for creating payment gateways
    /// </summary>
    public partial interface IPaymentMethod
    {
        #region Methods

        void ProcessPayment(PaymentInfo paymentInfo, Customer customer, 
            Guid orderGuid, ref ProcessPaymentResult processPaymentResult);

        string PostProcessPayment(Order order);


        decimal GetAdditionalHandlingFee();
        

        void Capture(Order order, ref ProcessPaymentResult processPaymentResult);

        void Refund(Order order, ref CancelPaymentResult cancelPaymentResult);

        void Void(Order order, ref CancelPaymentResult cancelPaymentResult);

        void ProcessRecurringPayment(PaymentInfo paymentInfo, Customer customer, 
            Guid orderGuid, ref ProcessPaymentResult processPaymentResult);

        void CancelRecurringPayment(Order order, ref CancelPaymentResult cancelPaymentResult);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether capture is supported
        /// </summary>
        bool CanCapture { get; }

        /// <summary>
        /// Gets a value indicating whether partial refund is supported
        /// </summary>
        bool CanPartiallyRefund { get; }

        /// <summary>
        /// Gets a value indicating whether refund is supported
        /// </summary>
        bool CanRefund { get; }

        /// <summary>
        /// Gets a value indicating whether void is supported
        /// </summary>
        bool CanVoid { get; }

        
        /// <summary>
        /// Gets a payment method type
        /// </summary>
        /// <returns>A payment method type</returns>
        PaymentMethodTypeEnum PaymentMethodType { get; }
                
        #endregion
    }
}
