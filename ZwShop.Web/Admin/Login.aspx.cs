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
        private void ApplyLocalization()
        {
            Literal lUsernameOrEmail = LoginForm.FindControl("lUsernameOrEmail") as Literal;
            if (lUsernameOrEmail != null)
            {
                if (this.CustomerService.UsernamesEnabled)
                {
                    lUsernameOrEmail.Text ="用户名";
                }
                else
                {
                    lUsernameOrEmail.Text = "E-Mail";
                }
            }
            RequiredFieldValidator UserNameOrEmailRequired = LoginForm.FindControl("UserNameOrEmailRequired") as RequiredFieldValidator;
            if (UserNameOrEmailRequired != null)
            {
                if (this.CustomerService.UsernamesEnabled)
                {
                    UserNameOrEmailRequired.ErrorMessage = "用户名必填";
                    UserNameOrEmailRequired.ToolTip = "用户名必填";
                }
                else
                {
                    UserNameOrEmailRequired.ErrorMessage = "邮箱必填";
                    UserNameOrEmailRequired.ToolTip = "邮箱必填";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ApplyLocalization();

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