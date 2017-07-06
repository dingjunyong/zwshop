using System;
using System.Configuration;
using System.Data;
using System.IO;
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
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Directory;
using ZwShop.Common.Utils;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web
{
    public partial class BaseShopFrontendMasterPage : BaseShopMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }

           
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            AddPoweredBy();
        }

      
        protected void AddPoweredBy()
        {
            StringBuilder poweredBy = new StringBuilder();
            poweredBy.Append(Environment.NewLine);
            poweredBy.Append("<!--Powered by 一元战网 - http://www.1yzw.com-->");
            poweredBy.Append(Environment.NewLine);
            poweredBy.Append("<!--Copyright (c) 2017-2020-->");
            poweredBy.Append(Environment.NewLine);
            Page.Header.Controls.AddAt(Page.Header.Controls.Count, new LiteralControl(poweredBy.ToString()));
        }
    }
}