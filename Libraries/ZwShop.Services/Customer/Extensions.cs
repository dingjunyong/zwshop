

using System;
using System.Collections.Generic;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Profile;

namespace ZwShop.Services.CustomerManagement
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        public static Address FindAddress(this List<Address> source,
            string name, string phoneNumber,
            string email, string faxNumber, string company, string address1,
            string address2, string city, int stateProvinceId,
            string zipPostalCode, int countryId)
        {
            return source.Find((a) => a.Name == name &&
               a.PhoneNumber == phoneNumber &&
               a.Email == email &&
               a.Address1 == address1 &&
               a.Address2 == address2 &&
               a.City == city &&
               a.StateProvinceId == stateProvinceId &&
               a.ZipPostalCode == zipPostalCode &&
               a.CountryId == countryId);
        }

        /// <summary>
        /// Returns a customer attribute that has the specified attribute value
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="key">Customer attribute key</param>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer attribute that has the specified attribute value; otherwise null</returns>
        public static CustomerAttribute FindAttribute(this List<CustomerAttribute> source, 
            string key, int customerId)
        {
            foreach (CustomerAttribute customerAttribute in source)
            {
                if (customerAttribute.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase) &&
                    customerAttribute.CustomerId == customerId)
                    return customerAttribute;
            }
            return null;
        }

        /// <summary>
        /// Formats the customer name
        /// </summary>
        /// <param name="customer">Source</param>
        /// <returns>Formatted text</returns>
        public static string FormatUserName(this Customer customer)
        {
            return FormatUserName(customer, false);
        }

        /// <summary>
        /// Formats the customer name
        /// </summary>
        /// <param name="customer">Source</param>
        /// <param name="stripTooLong">Strip too long customer name</param>
        /// <returns>Formatted text</returns>
        public static string FormatUserName(this Customer customer, bool stripTooLong)
        {
            if (customer == null)
                return string.Empty;

            if (customer.IsGuest)
            {
                return IoC.Resolve<ILocalizationManager>().GetLocaleResourceString("Customer.Guest");
            }

            string result = string.Empty;
            switch (IoC.Resolve<ICustomerService>().CustomerNameFormatting)
            {
                case CustomerNameFormatEnum.ShowEmails:
                    result = customer.Email;
                    break;
                case CustomerNameFormatEnum.ShowFullNames:
                    result = customer.FullName;
                    break;
                case CustomerNameFormatEnum.ShowUsernames:
                    result = customer.Username;
                    break;
                default:
                    break;
            }

            if (stripTooLong)
            {
                int maxLength = IoC.Resolve<ISettingManager>().GetSettingValueInteger("Customer.FormatNameMaxLength", 0);
                if (maxLength > 0 && result.Length > maxLength)
                {
                    result = result.Substring(0, maxLength);
                }
            }

            return result;
        }
    }
}
