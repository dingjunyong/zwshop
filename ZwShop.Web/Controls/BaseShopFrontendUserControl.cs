using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZwShop.Services;
using ZwShop.Services.Directory;
using ZwShop.Common.Utils;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web
{
    public partial class BaseShopFrontendUserControl: BaseShopUserControl
    {
        protected void DisplayAlertMessage(string message)
        {
            if (String.IsNullOrEmpty(message))
                return;

            this.BindJQuery();
            StringBuilder alertJsStart = new StringBuilder();
            alertJsStart.AppendLine("<script type=\"text/javascript\">");
            alertJsStart.AppendLine("$(document).ready(function() {");
            alertJsStart.AppendLine(string.Format("alert('{0}');", message.Trim()));
            alertJsStart.AppendLine("});");
            alertJsStart.AppendLine("</script>");
            string js = alertJsStart.ToString();
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alertScriptKey", js);
        }
    }
}