using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZwShop.Services;
using ZwShop.Services.Audit;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Directory;
using ZwShop.Common.Utils;
using System.Collections.Generic;
using AjaxControlToolkit;
using ZwShop.Services.Audit.UsersOnline;
using ZwShop.Services.Infrastructure;


namespace ZwShop.Web
{
    public partial class BaseShopAdminPage : BaseShopPage
    {
        #region Methods

        protected void SelectTab(TabContainer tabContainer, string tabId)
        {
            if (tabContainer == null)
                throw new ArgumentNullException("tabContainer");

            if (!String.IsNullOrEmpty(tabId))
            {
                AjaxControlToolkit.TabPanel tab = tabContainer.FindControl(tabId) as AjaxControlToolkit.TabPanel;
                if (tab != null)
                {
                    tabContainer.ActiveTab = tab;
                }
            }
        }

        protected string GetActiveTabId(TabContainer tabContainer)
        {
            if (tabContainer == null)
                throw new ArgumentNullException("tabContainer");

            if (tabContainer.ActiveTab != null)
                return tabContainer.ActiveTab.ID;

            return string.Empty;
        }

        protected override void OnPreInit(EventArgs e)
        {
            //admin user validation
            if (this.AdministratorSecurityValidationEnabled &&
                !ValidateAdministratorSecurity())
            {
                //string url = SEOHelper.GetAdminAreaLoginPageUrl();
                string url = "";
                Response.Redirect(url);
            }

            //page security validation
            if (!ValidatePageSecurity())
            {
                //string url = SEOHelper.GetAdminAreaAccessDeniedUrl();
                string url = "";
                Response.Redirect(url);
            }

            if(this.IPAddressValidationEnabled && !ValidateIP())
            {
                //string url=SEOHelper.GetAdminAreaAccessDeniedUrl()
                string url = "";
                Response.Redirect(url);
            }

            base.OnPreInit(e);
        }

        /// <summary>
        /// Validates page security for current user
        /// </summary>
        /// <returns>true if action is allow; otherwise false</returns>
        protected virtual bool ValidatePageSecurity()
        {
            return true;
        }

        /// <summary>
        /// Validates admin security
        /// </summary>
        /// <returns>true if admin access is allow; otherwise false</returns>
        protected virtual bool ValidateAdministratorSecurity()
        {
            if (ShopContext.Current == null ||
                ShopContext.Current.User == null ||
                ShopContext.Current.User.IsGuest)
                return false;

            return ShopContext.Current.User.IsAdmin;
        }

        protected virtual bool ValidateIP()
        {
            string ipList = this.SettingManager.GetSettingValue("Security.AdminAreaAllowedIP").Trim();
            if(String.IsNullOrEmpty(ipList))
            {
                return true;
            }
            foreach (string s in ipList.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Trim().Equals(ShopContext.Current.UserHostAddress))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            CommonHelper.EnsureSsl();
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //java-script
            string adminJs = CommonHelper.GetStoreLocation() + "Scripts/admin.js";
            Page.ClientScript.RegisterClientScriptInclude(adminJs, adminJs);

            base.OnPreRender(e);
        }
       
        protected void ProcessException(Exception exc)
        {
            ProcessException(exc, true);
        }

        protected void ProcessException(Exception exc, bool showError)
        {
            this.LogService.InsertLog(LogTypeEnum.AdministrationArea, exc.Message, exc);
            if (showError)
            {
                if (this.SettingManager.GetSettingValueBoolean("Display.AdminArea.ShowFullErrors"))
                {
                    ShowError(exc.Message, exc.ToString());
                }
                else
                {
                    ShowError(exc.Message, string.Empty);
                }
            }
        }
        
        protected void ShowMessage(string message)
        {
            MasterPage masterPage = this.Master;
            if (masterPage == null)
                return;

            BaseShopAdminMasterPage ShopAdministrationMasterPage = masterPage as BaseShopAdminMasterPage;
            if (ShopAdministrationMasterPage != null)
                ShopAdministrationMasterPage.ShowMessage(message);
        }

        protected void ShowError(string message)
        {
            ShowError(message, string.Empty);
        }

        protected void ShowError(string message, string completeMessage)
        {
            MasterPage masterPage = this.Master;
            if (masterPage == null)
                return;

            BaseShopAdminMasterPage ShopAdministrationMasterPage = masterPage as BaseShopAdminMasterPage;
            if (ShopAdministrationMasterPage != null)
                ShopAdministrationMasterPage.ShowError(message, completeMessage);
        }
        
        #endregion

        #region Properties

        protected virtual bool AdministratorSecurityValidationEnabled
        {
            get
            {
                return true;
            }
        }

        protected virtual bool IPAddressValidationEnabled
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}
