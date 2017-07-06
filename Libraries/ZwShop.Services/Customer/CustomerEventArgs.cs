using System;

namespace ZwShop.Services.CustomerManagement
{
    public partial class CustomerEventArgs : EventArgs
    {
        public Customer Customer { get; set; }
    }
}
