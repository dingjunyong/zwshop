namespace ZwShop.Services.Messages.SMS
{
    public partial interface ISMSProvider
    {
        bool SendSMS(string text);
    }
}
