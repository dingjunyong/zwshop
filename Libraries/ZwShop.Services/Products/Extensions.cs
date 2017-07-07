using System;
using System.Collections.Generic;
using ZwShop.Services.Infrastructure;
using ZwShop.Common.Utils;
using ZwShop.Common.Utils.Html;

namespace ZwShop.Services.Products
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {

        public static string FormatProductReviewText(this ProductReview productReview)
        {
            if (productReview == null || String.IsNullOrEmpty(productReview.ReviewText))
                return string.Empty;

            string result = HtmlHelper.FormatText(productReview.ReviewText, false, true, false, false, false, false);
            return result;
        }

    }
}
