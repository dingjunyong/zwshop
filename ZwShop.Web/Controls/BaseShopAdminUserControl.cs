using System;
using System.Collections.Generic;
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
using AjaxControlToolkit;
using ZwShop.Services;
using ZwShop.Services.Audit;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Directory;
using ZwShop.Common.Utils;
using ZwShop.Services.Infrastructure;

namespace ZwShop.Web
{
    public partial class BaseShopAdminUserControl: BaseShopUserControl
    {
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
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
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
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return;

            BaseShopAdminMasterPage ShopAdministrationMasterPage = masterPage as BaseShopAdminMasterPage;
            if (ShopAdministrationMasterPage != null)
                ShopAdministrationMasterPage.ShowError(message, completeMessage);
        }

       
    }
}