using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Audit;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Data;
using ZwShop.Services.Directory;
using ZwShop.Services.Payment;
using ZwShop.Services.Products;
using ZwShop.Services.Shipping;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Orders
{
    public partial class ShoppingCartService : IShoppingCartService
    {
        public void DeleteExpiredShoppingCartItems(DateTime olderThan)
        {
            throw new NotImplementedException();
        }

        public void DeleteShoppingCartItem(int shoppingCartItemId, bool resetCheckoutData)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetShoppingCartByCustomerSessionGuid(ShoppingCartTypeEnum shoppingCartType, Guid customerSessionGuid)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartItem GetShoppingCartItemById(int shoppingCartItemId)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetCurrentShoppingCart(ShoppingCartTypeEnum shoppingCartType)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetCustomerShoppingCart(int customerId, ShoppingCartTypeEnum shoppingCartType)
        {
            throw new NotImplementedException();
        }

        public decimal? GetShoppingCartTotal(ShoppingCart cart, int paymentMethodId, Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal? GetShoppingCartTotal(ShoppingCart cart, int paymentMethodId, Customer customer, bool useRewardPoints)
        {
            throw new NotImplementedException();
        }

        public decimal? GetShoppingCartTotal(ShoppingCart cart, int paymentMethodId, Customer customer, out decimal discountAmount, bool useRewardPoints, out int redeemedRewardPoints, out decimal redeemedRewardPointsAmount)
        {
            throw new NotImplementedException();
        }

        public string GetShoppingCartSubTotal(ShoppingCart cart, Customer customer, out decimal discountAmount, out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount)
        {
            throw new NotImplementedException();
        }

        public string GetShoppingCartSubTotal(ShoppingCart cart, Customer customer, bool includingTax, out decimal discountAmount, out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount)
        {
            throw new NotImplementedException();
        }

        public string GetShoppingCartSubTotal(ShoppingCart cart, Customer customer, bool includingTax, out decimal discountAmount, out decimal subTotalWithoutDiscount, out decimal subTotalWithDiscount, out SortedDictionary<decimal, decimal> taxRates)
        {
            throw new NotImplementedException();
        }

        public List<string> GetShoppingCartItemWarnings(ShoppingCartTypeEnum shoppingCartType, int productVariantId, string selectedAttributes, decimal customerEnteredPrice, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<string> GetShoppingCartItemAttributeWarnings(ShoppingCartTypeEnum shoppingCartType, int productVariantId, string selectedAttributes, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<string> GetShoppingCartItemAttributeWarnings(ShoppingCartTypeEnum shoppingCartType, int productVariantId, string selectedAttributes, int quantity, bool validateQuantity)
        {
            throw new NotImplementedException();
        }

        public List<string> GetShoppingCartItemGiftCardWarnings(ShoppingCartTypeEnum shoppingCartType, int productVariantId, string selectedAttributes)
        {
            throw new NotImplementedException();
        }

        public List<string> GetShoppingCartWarnings(ShoppingCart shoppingCart, string checkoutAttributes, bool validateCheckoutAttributes)
        {
            throw new NotImplementedException();
        }

        public string GetReccuringCycleInfo(ShoppingCart shoppingCart, out int cycleLength, out int cyclePeriod, out int totalCycles)
        {
            throw new NotImplementedException();
        }

        public List<string> AddToCart(ShoppingCartTypeEnum shoppingCartType, int productVariantId, string selectedAttributes, decimal customerEnteredPrice, int quantity)
        {
            throw new NotImplementedException();
        }

        public List<string> UpdateCart(int shoppingCartItemId, int newQuantity, bool resetCheckoutData)
        {
            throw new NotImplementedException();
        }
    }
}
