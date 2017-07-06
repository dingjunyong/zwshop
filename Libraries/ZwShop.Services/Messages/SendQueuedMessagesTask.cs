using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Xml;
using ZwShop.Services.Audit;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Tasks;

namespace ZwShop.Services.Messages
{
    /// <summary>
    /// Represents a task for sending queued message 
    /// </summary>
    public partial class SendQueuedMessagesTask : ITask
    {
        private int _maxTries = 5;

        /// <summary>
        /// Executes a task
        /// </summary>
        /// <param name="node">Xml node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            XmlAttribute attribute1 = node.Attributes["maxTries"];
            if (attribute1 != null && !String.IsNullOrEmpty(attribute1.Value))
            {
                this._maxTries = int.Parse(attribute1.Value);
            }

            var queuedEmails = IoC.Resolve<IMessageService>().GetAllQueuedEmails(10000, true, _maxTries);
            foreach (QueuedEmail queuedEmail in queuedEmails)
            {
                List<string> bcc = new List<string>();
                foreach (string str1 in queuedEmail.Bcc.Split(new char[] { ';' },  StringSplitOptions.RemoveEmptyEntries))
                {
                    bcc.Add(str1);
                }
                List<string> cc = new List<string>();
                foreach (string str1 in queuedEmail.CC.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    cc.Add(str1);
                }

                try
                {
                    IoC.Resolve<IMessageService>().SendEmail(queuedEmail.Subject, queuedEmail.Body,
                       new MailAddress(queuedEmail.From, queuedEmail.FromName),
                       new MailAddress(queuedEmail.To, queuedEmail.ToName), bcc, cc, queuedEmail.EmailAccount);

                    queuedEmail.SendTries = queuedEmail.SendTries + 1;
                    queuedEmail.SentOn = DateTime.UtcNow;
                    IoC.Resolve<IMessageService>().UpdateQueuedEmail(queuedEmail);
                }
                catch (Exception exc)
                {
                    queuedEmail.SendTries = queuedEmail.SendTries + 1;
                    IoC.Resolve<IMessageService>().UpdateQueuedEmail(queuedEmail);

                    IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.MailError, string.Format("Error sending e-mail. {0}", exc.Message), exc);
                }
            }
        }

    }
}
