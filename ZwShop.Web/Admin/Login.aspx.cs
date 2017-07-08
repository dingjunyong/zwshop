using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Common.Utils;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web.Admin
{
    public partial class Login : BaseShopAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonHelper.SetResponseNoCache(Response);
        }

        protected override bool AdministratorSecurityValidationEnabled
        {
            get
            {
                return false;
            }
        }

        protected override bool IPAddressValidationEnabled
        {
            get
            {
                return false;
            }
        }
    }
}