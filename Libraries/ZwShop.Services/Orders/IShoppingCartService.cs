using System;
using System.Collections.Generic;
using ZwShop.Services.CustomerManagement;

namespace ZwShop.Services.Orders
{
    public partial interface IShoppingCartService
    {
        void DeleteExpiredShoppingCartItems(DateTime olderThan);

        void DeleteShoppingCartItem(int shoppingCartItemId, bool resetCheckoutData);

        ShoppingCart GetShoppingCartByCustomerSessionGuid(ShoppingCartTypeEnum shoppingCartType,
            Guid customerSessionGuid);

        ShoppingCartItem GetShoppingCartItemById(int shoppingCartItemId);

        ShoppingCart GetCurrentShoppingCart(ShoppingCartTypeEnum shoppingCartType);

        ShoppingCart GetCustomerShoppingCart(int customerId,
            ShoppingCartTypeEnum shoppingCartType);

        decimal? GetShoppingCartTotal(ShoppingCart cart,
            int paymentMethodId, Customer customer);

        decimal? GetShoppingCartTotal(ShoppingCart cart,
            int paymentMethodId, Customer customer, bool useRewardPoints);

        decimal? GetShoppingCartTotal(ShoppingCart cart,
            int paymentMethodId, Customer customer,
            out decimal discountAmount, 
            bool useRewardPoints, out int redeemedRewardPoints, out decimal redeemedRewardPointsAmount);

        string GetShoppingCartSubTotal(ShoppingCart cart,
            Customer customer, out decimal discountAmount,
            out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount);

        string GetShoppingCartSubTotal(ShoppingCart cart,
            Customer customer, bool includingTax,
            out decimal discountAmount,
            out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount);

        string GetShoppingCartSubTotal(ShoppingCart cart,
            Customer customer, bool includingTax,
            out decimal discountAmount,
            out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount,
            out SortedDictionary<decimal, decimal> taxRates);


        List<string> GetShoppingCartItemWarnings(ShoppingCartTypeEnum shoppingCartType,
            int productVariantId, string selectedAttributes, decimal customerEnteredPrice,
            int quantity);

        List<string> GetShoppingCartItemAttributeWarnings(ShoppingCartTypeEnum shoppingCartType,
            int productVariantId, string selectedAttributes, int quantity);

        List<string> GetShoppingCartItemAttributeWarnings(ShoppingCartTypeEnum shoppingCartType,
            int productVariantId, string selectedAttributes, int quantity, bool validateQuantity);

        List<string> GetShoppingCartItemGiftCardWarnings(ShoppingCartTypeEnum shoppingCartType,
            int productVariantId, string selectedAttributes);

        List<string> GetShoppingCartWarnings(ShoppingCart shoppingCart, string checkoutAttributes, bool validateCheckoutAttributes);

        string GetReccuringCycleInfo(ShoppingCart shoppingCart,
            out int cycleLength, out int cyclePeriod, out int totalCycles);

        List<string> AddToCart(ShoppingCartTypeEnum shoppingCartType,
            int productVariantId, string selectedAttributes,
            decimal customerEnteredPrice, int quantity);

        List<string> UpdateCart(int shoppingCartItemId, int newQuantity,
            bool resetCheckoutData);
    }
}
