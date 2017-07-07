using System.Collections.Generic;
using System;

namespace ZwShop.Services.Content.Topics
{
    public partial class Topic : BaseEntity
    {
        #region Properties


        public string Name { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IncludeInSitemap { get; set; }

        #endregion

    }

}
