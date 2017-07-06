using System;
using System.Collections.Generic;
using System.Net.Mail;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Orders;
using ZwShop.Services.Products;

namespace ZwShop.Services.Messages
{
    public partial interface IMessageService
    {
        MessageTemplate GetMessageTemplateById(int messageTemplateId);

        List<MessageTemplate> GetAllMessageTemplates();
         
        QueuedEmail GetQueuedEmailById(int queuedEmailId);

        void DeleteQueuedEmail(int queuedEmailId);

        List<QueuedEmail> GetAllQueuedEmails(int queuedEmailCount, 
            bool loadNotSentItemsOnly, int maxSendTries);

        List<QueuedEmail> GetAllQueuedEmails(string fromEmail,
            string toEmail, DateTime? startTime, DateTime? endTime,
            int queuedEmailCount, bool loadNotSentItemsOnly, int maxSendTries);

        QueuedEmail InsertQueuedEmail(int priority, MailAddress from,
            MailAddress to, string cc, string bcc,
            string subject, string body, DateTime createdOn, int sendTries,
            DateTime? sentOn, int emailAccountId);

        QueuedEmail InsertQueuedEmail(int priority, string from,
            string fromName, string to, string toName, string cc, string bcc,
            string subject, string body, DateTime createdOn, int sendTries,
            DateTime? sentOn, int emailAccountId);

        void UpdateQueuedEmail(QueuedEmail queuedEmail);

        void InsertNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription);

        NewsLetterSubscription GetNewsLetterSubscriptionById(int newsLetterSubscriptionId);

        NewsLetterSubscription GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid);

        NewsLetterSubscription GetNewsLetterSubscriptionByEmail(string email);

        List<NewsLetterSubscription> GetAllNewsLetterSubscriptions(string email, bool showHidden);

        void UpdateNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription);

        void DeleteNewsLetterSubscription(int newsLetterSubscriptionId);

        EmailAccount GetEmailAccountById(int emailAccountId);

        void DeleteEmailAccount(int emailAccountId);

        void InsertEmailAccount(EmailAccount emailAccount);

        void UpdateEmailAccount(EmailAccount emailAccount);

        List<EmailAccount> GetAllEmailAccounts();


        void SendEmail(string subject, string body, string from, string to, 
            EmailAccount emailAccount);


        void SendEmail(string subject, string body, MailAddress from,
            MailAddress to, EmailAccount emailAccount);

        void SendEmail(string subject, string body,
            MailAddress from, MailAddress to, List<string> bcc, 
            List<string> cc, EmailAccount emailAccount);

        EmailAccount DefaultEmailAccount { get; set; }
    }
}