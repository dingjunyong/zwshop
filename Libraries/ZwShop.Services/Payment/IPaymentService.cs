using System;
using System.Collections.Generic;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Orders;

namespace ZwShop.Services.Payment
{
    public partial interface IPaymentService
    {
        #region Payment methods

        /// <summary>
        /// Deletes a payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        void DeletePaymentMethod(int paymentMethodId);

        /// <summary>
        /// Gets a payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>Payment method</returns>
        PaymentMethod GetPaymentMethodById(int paymentMethodId);

        /// <summary>
        /// Gets a payment method
        /// </summary>
        /// <param name="systemKeyword">Payment method system keyword</param>
        /// <returns>Payment method</returns>
        PaymentMethod GetPaymentMethodBySystemKeyword(string systemKeyword);

        /// <summary>
        /// Gets all payment methods
        /// </summary>
        /// <returns>Payment method collection</returns>
        List<PaymentMethod> GetAllPaymentMethods();

        /// <summary>
        /// Gets all payment methods
        /// </summary>
        /// <param name="filterByCountryId">The country indentifier</param>
        /// <returns>Payment method collection</returns>
        List<PaymentMethod> GetAllPaymentMethods(int? filterByCountryId);

        /// <summary>
        /// Gets all payment methods
        /// </summary>
        /// <param name="filterByCountryId">The country indentifier</param>
        /// <param name="showHidden">A value indicating whether the not active payment methods should be load</param>
        /// <returns>Payment method collection</returns>
        List<PaymentMethod> GetAllPaymentMethods(int? filterByCountryId, bool showHidden);

        /// <summary>
        /// Inserts a payment method
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        void InsertPaymentMethod(PaymentMethod paymentMethod);

        /// <summary>
        /// Updates the payment method
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        void UpdatePaymentMethod(PaymentMethod paymentMethod);

        /// <summary>
        /// Creates the payment method country mapping
        /// </summary>
        /// <param name="paymentMethodId">The payment method identifier</param>
        /// <param name="countryId">The country identifier</param>
        void CreatePaymentMethodCountryMapping(int paymentMethodId, int countryId);

        /// <summary>
        /// Checking whether the payment method country mapping exists
        /// </summary>
        /// <param name="paymentMethodId">The payment method identifier</param>
        /// <param name="countryId">The country identifier</param>
        /// <returns>True if mapping exist, otherwise false</returns>
        bool DoesPaymentMethodCountryMappingExist(int paymentMethodId, int countryId);

        /// <summary>
        /// Deletes the payment method country mapping
        /// </summary>
        /// <param name="paymentMethodId">The payment method identifier</param>
        /// <param name="countryId">The country identifier</param>
        void DeletePaymentMethodCountryMapping(int paymentMethodId, int countryId);

        #endregion

        #region Workflow

        /// <summary>
        /// Process payment
        /// </summary>
        /// <param name="paymentInfo">Payment info required for an order processing</param>
        /// <param name="customer">Customer</param>
        /// <param name="orderGuid">Unique order identifier</param>
        /// <param name="processPaymentResult">Process payment result</param>
        void ProcessPayment(PaymentInfo paymentInfo, Customer customer,
            Guid orderGuid, ref ProcessPaymentResult processPaymentResult);

        /// <summary>
        /// Post process payment (payment gateways that require redirecting)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>The error status, or String.Empty if no errors</returns>
        string PostProcessPayment(Order order);

        /// <summary>
        /// Gets additional handling fee
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>Additional handling fee</returns>
        decimal GetAdditionalHandlingFee(int paymentMethodId);

        /// <summary>
        /// Gets a value indicating whether capture is supported by payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>A value indicating whether capture is supported</returns>
        bool CanCapture(int paymentMethodId);
        
        /// <summary>
        /// Captures payment
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="processPaymentResult">Process payment result</param>
        void Capture(Order order, ref ProcessPaymentResult processPaymentResult);

        /// <summary>
        /// Gets a value indicating whether partial refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>A value indicating whether partial refund is supported</returns>
        bool CanPartiallyRefund(int paymentMethodId);

        /// <summary>
        /// Gets a value indicating whether refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>A value indicating whether refund is supported</returns>
        bool CanRefund(int paymentMethodId);

        /// <summary>
        /// Refunds payment
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="cancelPaymentResult">Cancel payment result</param>
        void Refund(Order order, ref CancelPaymentResult cancelPaymentResult);

        /// <summary>
        /// Gets a value indicating whether void is supported by payment method
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>A value indicating whether void is supported</returns>
        bool CanVoid(int paymentMethodId);

        /// <summary>
        /// Voids payment
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="cancelPaymentResult">Cancel payment result</param>
        void Void(Order order, ref CancelPaymentResult cancelPaymentResult);



        /// <summary>
        /// Gets a payment method type
        /// </summary>
        /// <param name="paymentMethodId">Payment method identifier</param>
        /// <returns>A payment method type</returns>
        PaymentMethodTypeEnum GetPaymentMethodType(int paymentMethodId);

        /// <summary>
        /// Process recurring payments
        /// </summary>
        /// <param name="paymentInfo">Payment info required for an order processing</param>
        /// <param name="customer">Customer</param>
        /// <param name="orderGuid">Unique order identifier</param>
        /// <param name="processPaymentResult">Process payment result</param>
        void ProcessRecurringPayment(PaymentInfo paymentInfo, Customer customer,
            Guid orderGuid, ref ProcessPaymentResult processPaymentResult);

        /// <summary>
        /// Cancels recurring payment
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="cancelPaymentResult">Cancel payment result</param>
        void CancelRecurringPayment(Order order, ref CancelPaymentResult cancelPaymentResult);

        /// <summary>
        /// Gets masked credit card number
        /// </summary>
        /// <param name="creditCardNumber">Credit card number</param>
        /// <returns>Masked credit card number</returns>
        string GetMaskedCreditCardNumber(string creditCardNumber);

        #endregion
    }
}
