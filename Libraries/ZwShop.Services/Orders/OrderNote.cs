

using System;

namespace ZwShop.Services.Orders
{
    /// <summary>
    /// Represents an order note
    /// </summary>
    public partial class OrderNote : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the order note identifier
        /// </summary>
        public int OrderNoteId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer can see a note
        /// </summary>
        public bool DisplayToCustomer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time of order note creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the order
        /// </summary>
        public virtual Order NpOrder { get; set; }

        #endregion
    }

}
