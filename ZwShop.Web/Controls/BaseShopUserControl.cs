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
using ZwShop.Services.Audit;
using ZwShop.Services.Audit.UsersOnline;
using ZwShop.Services.Categories;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Content.Topics;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Directory;
using ZwShop.Services.ExportImport;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Brands;
using ZwShop.Services.Media;
using ZwShop.Services.Messages;
using ZwShop.Services.Messages.SMS;
using ZwShop.Services.Orders;
using ZwShop.Services.Payment;
using ZwShop.Services.Products;
using ZwShop.Services.Products.Attributes;
using ZwShop.Services.Products.Specs;
using ZwShop.Services.Security;
using ZwShop.Services.Shipping;
using ZwShop.Common.Utils;

namespace ZwShop.Web
{
    public partial class BaseShopUserControl : UserControl
    {
        protected virtual void BindJQuery()
        {
            CommonHelper.BindJQuery(this.Page);
        }

        protected virtual void BindJQueryIdTabs()
        {
            string jqueryTabs = CommonHelper.GetStoreLocation() + "Scripts/jquery.idTabs.min.js";
            Page.ClientScript.RegisterClientScriptInclude(jqueryTabs, jqueryTabs);
        }
        
       

        #region Services, managers

        public IOnlineUserService OnlineUserService
        {
            get { return IoC.Resolve<IOnlineUserService>(); }
        }
        public ICustomerActivityService CustomerActivityService
        {
            get { return IoC.Resolve<ICustomerActivityService>(); }
        }
        public ILogService LogService
        {
            get { return IoC.Resolve<ILogService>(); }
        }
        public ISearchLogService SearchLogService
        {
            get { return IoC.Resolve<ISearchLogService>(); }
        }
        public ICategoryService CategoryService
        {
            get { return IoC.Resolve<ICategoryService>(); }
        }
        public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }
       
        public ITopicService TopicService
        {
            get { return IoC.Resolve<ITopicService>(); }
        }
        public ICustomerService CustomerService
        {
            get { return IoC.Resolve<ICustomerService>(); }
        }
        
        public IStateProvinceService StateProvinceService
        {
            get { return IoC.Resolve<IStateProvinceService>(); }
        }
        public IExportManager ExportManager
        {
            get { return IoC.Resolve<IExportManager>(); }
        }
        public IImportManager ImportManager
        {
            get { return IoC.Resolve<IImportManager>(); }
        }
       
        public IPictureService PictureService
        {
            get { return IoC.Resolve<IPictureService>(); }
        }
        public ISMSService SMSService
        {
            get { return IoC.Resolve<ISMSService>(); }
        }
        public IMessageService MessageService
        {
            get { return IoC.Resolve<IMessageService>(); }
        }
        public IOrderService OrderService
        {
            get { return IoC.Resolve<IOrderService>(); }
        }
       
        public IPaymentService PaymentService
        {
            get { return IoC.Resolve<IPaymentService>(); }
        }
        public ICheckoutAttributeService CheckoutAttributeService
        {
            get { return IoC.Resolve<ICheckoutAttributeService>(); }
        }
        public IProductAttributeService ProductAttributeService
        {
            get { return IoC.Resolve<IProductAttributeService>(); }
        }
        public ISpecificationAttributeService SpecificationAttributeService
        {
            get { return IoC.Resolve<ISpecificationAttributeService>(); }
        }
        public IProductService ProductService
        {
            get { return IoC.Resolve<IProductService>(); }
        }
       
        public IBlacklistService BlacklistService
        {
            get { return IoC.Resolve<IBlacklistService>(); }
        }
       
        public IShippingService ShippingService
        {
            get { return IoC.Resolve<IShippingService>(); }
        }
       
        #endregion
    }
}