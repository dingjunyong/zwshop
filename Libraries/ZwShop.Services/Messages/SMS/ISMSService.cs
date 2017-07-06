using System.Collections.Generic;
using ZwShop.Services.Orders;

namespace ZwShop.Services.Messages.SMS
{
    public partial interface ISMSService
    {
        void DeleteSMSProvider(int smsProviderId);

        SMSProvider GetSMSProviderById(int smsProviderId);

        SMSProvider GetSMSProviderBySystemKeyword(string systemKeyword);

        List<SMSProvider> GetAllSMSProviders();

        List<SMSProvider> GetAllSMSProviders(bool showHidden);

        void InsertSMSProvider(SMSProvider smsProvider);


        void UpdateSMSProvider(SMSProvider smsProvider);


        int SendSMS(string text);

        void SendOrderPlacedNotification(Order order);
    }
}
