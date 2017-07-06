using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using ZwShop.Services.Audit.UsersOnline;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web
{
    public partial class BaseShopFrontendPage : BaseShopPage
    {
        #region Fields

        protected Stopwatch executionTimer;
        protected bool showExecutionTimer = false;

        #endregion

        #region Ctor

        public BaseShopFrontendPage()
        {
            showExecutionTimer = this.SettingManager.GetSettingValueBoolean("Display.PageExecutionTimeInfoEnabled");
            if (showExecutionTimer)
            {
                executionTimer = new Stopwatch();
            }
        }

        #endregion

        #region Overrides

        protected override void OnPreInit(EventArgs e)
        {
            //store is closed
            if (this.SettingManager.GetSettingValueBoolean("Common.StoreClosed"))
            {
                if (ShopContext.Current.User != null &&
                    ShopContext.Current.User.IsAdmin &&
                    this.SettingManager.GetSettingValueBoolean("Common.StoreClosed.AllowAdminAccess"))
                {
                    //do nothing - allow admin access
                }
                else
                {
                    Response.Redirect("~/StoreClosed.htm");
                }
            }

            //SSL
            switch (this.SslProtected)
            {
                case PageSslProtectionEnum.Yes:
                    {
                        CommonHelper.EnsureSsl();
                    }
                    break;
                case PageSslProtectionEnum.No:
                    {
                        CommonHelper.EnsureNonSsl();
                    }
                    break;
                case PageSslProtectionEnum.DoesntMatter:
                    {
                        //do nothing in this case
                    }
                    break;
            }

            //allow navigation only for registered customers
            if (this.CustomerService.AllowNavigationOnlyRegisteredCustomers)
            {
                if (ShopContext.Current.User == null || ShopContext.Current.User.IsGuest)
                {
                    if (!this.AllowGuestNavigation)
                    {
                        //it's not login/logout/passwordrecovery/captchaimage/register/accountactivation page (be default)
                        //string loginURL = SEOHelper.GetLoginPageUrl(false);
                        Response.Redirect("");
                    }
                }
            }

            //theme
            if (!String.IsNullOrEmpty(ShopContext.Current.WorkingTheme))
            {
                this.Theme = ShopContext.Current.WorkingTheme;
            }
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            if (showExecutionTimer)
            {
                executionTimer.Start();
            }

            base.OnInit(e);

            if (showExecutionTimer)
            {
                executionTimer.Stop();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (showExecutionTimer)
            {
                executionTimer.Start();
            }

            base.OnLoad(e);

            if (showExecutionTimer)
            {
                executionTimer.Stop();
            }
        }

        protected override void CreateChildControls()
        {
            if (showExecutionTimer)
            {
                executionTimer.Start();
            }

            base.CreateChildControls();

            if (showExecutionTimer)
            {
                executionTimer.Stop();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (showExecutionTimer)
            {
                executionTimer.Start();
            }

            base.Render(writer);

            if (showExecutionTimer)
            {
                executionTimer.Stop();
                RenderExecutionTimerValue(writer);
            }
        }
        
        protected override void OnPreRender(EventArgs e)
        {
            //java-script
            string publicJS = CommonHelper.GetStoreLocation() + "Scripts/public.js";
            Page.ClientScript.RegisterClientScriptInclude(publicJS, publicJS);

            base.OnPreRender(e);
        }
        #endregion

        #region Utiilities

        protected virtual void RenderExecutionTimerValue(HtmlTextWriter writer)
        {
            if (showExecutionTimer)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<div style=""color:#ffffff;background:#000000;font-weight:bold,padding:5px"">");
                sb.Append(String.Format("Page execution time is {0:F10}.<br />", executionTimer.Elapsed.TotalSeconds));
                sb.Append(@"</div>");
                writer.Write(sb.ToString());
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this page is SSL protected
        /// </summary>
        public virtual PageSslProtectionEnum SslProtected
        {
            get
            {
                return PageSslProtectionEnum.DoesntMatter;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this page can be visited by anonymous customer when "Allow navigation only for registered customers" settings is set to true
        /// </summary>
        public virtual bool AllowGuestNavigation
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}