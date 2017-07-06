using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZwShop.Services.Caching;

namespace ZwShop.Web.Admin
{
    public partial class Main : BaseShopAdminMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            string headerText = string.Format("一元战网 {0}", this.SettingManager.CurrentVersion);
            lblHeader.Text = headerText;
        }

        protected void lbClearCache_Click(object sender, EventArgs e)
        {
            new ShopStaticCache().Clear();
        }

        public override void ShowMessage(string message)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = "messageBox messageBoxSuccess";
            lMessage.Text = message;
        }

        public override void ShowError(string message, string completeMessage)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = "messageBox messageBoxError";
            lMessage.Text = message;
            lMessageComplete.Text = completeMessage;
        }
    }
}