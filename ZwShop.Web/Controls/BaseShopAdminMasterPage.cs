using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZwShop.Services;
using ZwShop.Services.Directory;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web
{
    public partial class BaseShopAdminMasterPage : BaseShopMasterPage
    {
        public virtual void ShowMessage(string message)
        {

        }

        public virtual void ShowError(string message, string completeMessage)
        {

        }
    }
}