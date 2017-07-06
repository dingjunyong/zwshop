
using System;

namespace ZwShop.Services.Messages.SMS
{
    /// <summary>
    /// Represents a SMS provider
    /// </summary>
    public partial class SMSProvider : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public string ClassName { get; set; }

        public string SystemKeyword { get; set; }

        public bool IsActive { get; set; }
        #endregion

        #region Custom properties
        /// <summary>
        /// Gets instance of ClassName type as ISMSProvider
        /// </summary>
        public ISMSProvider Instance
        {
            get
            {
                return Activator.CreateInstance(Type.GetType(ClassName)) as ISMSProvider;
            }
        }
        #endregion
    }
}