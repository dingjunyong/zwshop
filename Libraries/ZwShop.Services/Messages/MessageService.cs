using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Data;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;
using ZwShop.Services.Orders;
using ZwShop.Services.Products;
using ZwShop.Services.Profile;
using ZwShop.Services.Shipping;
using ZwShop.Common;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Messages
{
    /// <summary>
    /// Message service
    /// </summary>
    public partial class MessageService : IMessageService
    {
        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public MessageService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion


        public MessageTemplate GetMessageTemplateById(int messageTemplateId)
        {
            throw new NotImplementedException();
        }

        public List<MessageTemplate> GetAllMessageTemplates()
        {
            throw new NotImplementedException();
        }

        public QueuedEmail GetQueuedEmailById(int queuedEmailId)
        {
            throw new NotImplementedException();
        }

        public void DeleteQueuedEmail(int queuedEmailId)
        {
            throw new NotImplementedException();
        }

        public List<QueuedEmail> GetAllQueuedEmails(int queuedEmailCount, bool loadNotSentItemsOnly, int maxSendTries)
        {
            throw new NotImplementedException();
        }

        public List<QueuedEmail> GetAllQueuedEmails(string fromEmail, string toEmail, DateTime? startTime, DateTime? endTime, int queuedEmailCount, bool loadNotSentItemsOnly, int maxSendTries)
        {
            throw new NotImplementedException();
        }

        public QueuedEmail InsertQueuedEmail(int priority, MailAddress from, MailAddress to, string cc, string bcc, string subject, string body, DateTime createdOn, int sendTries, DateTime? sentOn, int emailAccountId)
        {
            throw new NotImplementedException();
        }

        public QueuedEmail InsertQueuedEmail(int priority, string from, string fromName, string to, string toName, string cc, string bcc, string subject, string body, DateTime createdOn, int sendTries, DateTime? sentOn, int emailAccountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateQueuedEmail(QueuedEmail queuedEmail)
        {
            throw new NotImplementedException();
        }

        public void InsertNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription)
        {
            throw new NotImplementedException();
        }

        public NewsLetterSubscription GetNewsLetterSubscriptionById(int newsLetterSubscriptionId)
        {
            throw new NotImplementedException();
        }

        public NewsLetterSubscription GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid)
        {
            throw new NotImplementedException();
        }

        public NewsLetterSubscription GetNewsLetterSubscriptionByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetterSubscription> GetAllNewsLetterSubscriptions(string email, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public void UpdateNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription)
        {
            throw new NotImplementedException();
        }

        public void DeleteNewsLetterSubscription(int newsLetterSubscriptionId)
        {
            throw new NotImplementedException();
        }

        public EmailAccount GetEmailAccountById(int emailAccountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmailAccount(int emailAccountId)
        {
            throw new NotImplementedException();
        }

        public void InsertEmailAccount(EmailAccount emailAccount)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmailAccount(EmailAccount emailAccount)
        {
            throw new NotImplementedException();
        }

        public List<EmailAccount> GetAllEmailAccounts()
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string subject, string body, string from, string to, EmailAccount emailAccount)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string subject, string body, MailAddress from, MailAddress to, EmailAccount emailAccount)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string subject, string body, MailAddress from, MailAddress to, List<string> bcc, List<string> cc, EmailAccount emailAccount)
        {
            throw new NotImplementedException();
        }

        public EmailAccount DefaultEmailAccount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}