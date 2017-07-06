//------------------------------------------------------------------------------
// The contents of this file are subject to the ShopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.

// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is ShopCommerce.
// The Initial Developer of the Original Code is ShopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Localization;
using ZwShop.Common.Utils;
using ZwShop.Common.Utils.Html;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Finds a related product item by specified identifiers
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="productId2">The second product identifier</param>
        /// <returns>Related product</returns>
        public static RelatedProduct FindRelatedProduct(this List<RelatedProduct> source,
            int productId1, int productId2)
        {
           foreach (RelatedProduct relatedProduct in source)
                if (relatedProduct.ProductId1 == productId1 && relatedProduct.ProductId2 == productId2)
                    return relatedProduct;
            return null;
        }

        /// <summary>
        /// Finds a cross-sell product item by specified identifiers
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="productId2">The second product identifier</param>
        /// <returns>Cross-sell product</returns>
        public static CrossSellProduct FindCrossSellProduct(this List<CrossSellProduct> source,
            int productId1, int productId2)
        {
            foreach (CrossSellProduct crossSellProduct in source)
                if (crossSellProduct.ProductId1 == productId1 && crossSellProduct.ProductId2 == productId2)
                    return crossSellProduct;
            return null;
        }
        
        /// <summary>
        ///  Formats the product review text
        /// </summary>
        /// <param name="productReview">Product review</param>
        /// <returns>Formatted text</returns>
        public static string FormatProductReviewText(this ProductReview productReview)
        {
            if (productReview == null || String.IsNullOrEmpty(productReview.ReviewText))
                return string.Empty;

            string result = HtmlHelper.FormatText(productReview.ReviewText, false, true, false, false, false, false);
            return result;
        }

        /// <summary>
        ///  Formats the email a friend text
        /// </summary>
        /// <param name="text">Text to format</param>
        /// <returns>Formatted text</returns>
        public static string FormatEmailAFriendText(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return string.Empty;

            string result = HtmlHelper.FormatText(text, false, true, false, false, false, false);
            return result;
        }

        /// <summary>
        /// Get low stock activity name
        /// </summary>
        /// <param name="lsa">Low stock activity</param>
        /// <returns>Low stock activity name</returns>
        public static string GetLowStockActivityName(this LowStockActivityEnum lsa)
        {
            string name = IoC.Resolve<ILocalizationManager>().GetLocaleResourceString(
                string.Format("LowStockActivity.{0}", (int)lsa),
                ShopContext.Current.WorkingLanguage.LanguageId,
                true,
                CommonHelper.ConvertEnum(lsa.ToString()));

            return name;
        }

        /// <summary>
        /// Formats the stock availability/quantity message
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <returns>The stock message</returns>
        public static string FormatStockMessage(this ProductVariant productVariant)
        {
            if (productVariant == null)
                throw new ArgumentNullException("productVariant");

            string stockMessage = string.Empty;

            var localizationManager = IoC.Resolve<ILocalizationManager>();

            if (productVariant.ManageInventory == (int)ManageInventoryMethodEnum.ManageStock
                && productVariant.DisplayStockAvailability)
            {
                switch (productVariant.Backorders)
                {
                    case (int)BackordersModeEnum.NoBackorders:
                        {
                            if (productVariant.StockQuantity > 0)
                            {
                                if (productVariant.DisplayStockQuantity)
                                {
                                    //display "in stock" with stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), string.Format(localizationManager.GetLocaleResourceString("Products.InStockWithQuantity"), productVariant.StockQuantity));
                                }
                                else
                                {
                                    //display "in stock" without stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.InStock"));
                                }
                            }
                            else
                            {
                                //display "out of stock"
                                stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.OutOfStock"));
                            }
                        }
                        break;
                    case (int)BackordersModeEnum.AllowQtyBelow0:
                        {
                            if (productVariant.StockQuantity > 0)
                            {
                                if (productVariant.DisplayStockQuantity)
                                {
                                    //display "in stock" with stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), string.Format(localizationManager.GetLocaleResourceString("Products.InStockWithQuantity"), productVariant.StockQuantity));
                                }
                                else
                                {
                                    //display "in stock" without stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.InStock"));
                                }
                            }
                            else
                            {
                                //display "in stock" without stock quantity
                                stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.InStock"));
                            }
                        }
                        break;
                    case (int)BackordersModeEnum.AllowQtyBelow0AndNotifyCustomer:
                        {
                            if (productVariant.StockQuantity > 0)
                            {
                                if (productVariant.DisplayStockQuantity)
                                {
                                    //display "in stock" with stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), string.Format(localizationManager.GetLocaleResourceString("Products.InStockWithQuantity"), productVariant.StockQuantity));
                                }
                                else
                                {
                                    //display "in stock" without stock quantity
                                    stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.InStock"));
                                }
                            }
                            else
                            {
                                //display "backorder" without stock quantity
                                stockMessage = string.Format(localizationManager.GetLocaleResourceString("Products.Availability"), localizationManager.GetLocaleResourceString("Products.Backordering"));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return stockMessage;
        }
    }
}
