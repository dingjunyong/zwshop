using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZwShop.Web.Modules
{
    public partial class SearchBox : BaseShopFrontendUserControl
    {
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchTerms.Text))
            {
                Response.Redirect(string.Format("~/search.aspx?searchterms={0}", HttpUtility.UrlEncode(txtSearchTerms.Text)));
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.txtSearchTerms.Attributes.Add("onfocus", string.Format("if(this.value=='{0}')this.value=''", GetLocaleResourceString("Search.SearchStoreTooltip")));
            txtSearchTerms.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnSearch.ClientID + "').click();return false;}} else {return true}; ");
            base.OnPreRender(e);
        }
    }
}