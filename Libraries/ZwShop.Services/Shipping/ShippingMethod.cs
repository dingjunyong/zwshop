using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZwShop.Services.Shipping
{
    public partial class ShippingMethod : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        #endregion

       
    }
}
