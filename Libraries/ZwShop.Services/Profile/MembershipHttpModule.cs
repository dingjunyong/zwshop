

using System;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Infrastructure;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Profile
{
    public class MembershipHttpModule : IHttpModule
    {
        #region Utilities
        /// <summary>
        /// Logout customer
        /// </summary>
        private void logout()
        {
            IoC.Resolve<ICustomerService>().Logout();
            string loginURL = string.Empty;
            if (ShopContext.Current != null)
            {
                if (ShopContext.Current.IsAdmin)
                    loginURL = "";
                else
                    loginURL = "";
                HttpContext.Current.Response.Redirect(loginURL);
            }
        }

        /// <summary>
        /// Handlers the AuthenticateRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            //authentication
            bool authenticated = false;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                authenticated = HttpContext.Current.User.Identity.IsAuthenticated;

            if (authenticated)
            {
                Customer customer = null;
                string name = HttpContext.Current.User.Identity.Name;
                if (IoC.Resolve<ICustomerService>().UsernamesEnabled)
                {
                    customer = IoC.Resolve<ICustomerService>().GetCustomerByUsername(name);
                }
                else
                {
                    customer = IoC.Resolve<ICustomerService>().GetCustomerByEmail(name);
                }

                if (customer != null)
                {
                    if (!String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name)
                        && customer.Active
                        && !customer.Deleted && !customer.IsGuest)
                    {
                        //impersonate user if required (currently used for 'phone order' support)
                        //and validate that the current user is admin
                        //and validate that we're in public store
                        if (customer.IsAdmin &&
                            !CommonHelper.IsAdmin() &&
                            customer.ImpersonatedCustomerGuid != Guid.Empty)
                        {
                            //set impersonated customer
                            var impersonatedCustomer = IoC.Resolve<ICustomerService>().GetCustomerByGuid(customer.ImpersonatedCustomerGuid);
                            if (impersonatedCustomer != null)
                            {
                                ShopContext.Current.User = impersonatedCustomer;
                                ShopContext.Current.IsCurrentCustomerImpersonated = true;
                                ShopContext.Current.OriginalUser = customer;
                            }
                            else
                            {
                                //set current customer
                                ShopContext.Current.User = customer;
                            }
                        }
                        else
                        {
                            //set current customer
                            ShopContext.Current.User = customer;
                        }

                        //set current customer session
                        var customerSession = IoC.Resolve<ICustomerService>().GetCustomerSessionByCustomerId(ShopContext.Current.User.Id);
                        if (customerSession == null)
                        {
                            customerSession = ShopContext.Current.GetSession(true);
                            customerSession.IsExpired = false;
                            customerSession.LastAccessed = DateTime.UtcNow;
                            customerSession.CustomerId = ShopContext.Current.User.Id;
                            customerSession = IoC.Resolve<ICustomerService>().SaveCustomerSession(customerSession.CustomerSessionGuid, customerSession.CustomerId, customerSession.LastAccessed, customerSession.IsExpired);
                        }
                        ShopContext.Current.Session = customerSession;
                    }
                    else
                    {
                        logout();
                    }
                }
                else
                {
                    logout();
                }
            }
            else
            {
                if (ShopContext.Current.Session != null)
                {
                    var guestCustomer = ShopContext.Current.Session.Customer;
                    if (guestCustomer != null && guestCustomer.Active && !guestCustomer.Deleted && guestCustomer.IsGuest)
                    {
                        ShopContext.Current.User = guestCustomer;
                    }
                }
            }
            
                          

        }

        /// <summary>
        /// Handlers the BeginRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            //update session last access time
            if (ShopContext.Current.Session != null)
            {
                var dtNow = DateTime.UtcNow;
                if (ShopContext.Current.Session.LastAccessed.AddMinutes(1.0) < dtNow)
                {
                    ShopContext.Current.Session.LastAccessed = dtNow;
                    ShopContext.Current.Session = IoC.Resolve<ICustomerService>().SaveCustomerSession(
                        ShopContext.Current.Session.CustomerSessionGuid,
                        ShopContext.Current.Session.CustomerId,
                        ShopContext.Current.Session.LastAccessed,
                        false);
                }
            }
        }

        /// <summary>
        /// Handlers the EndRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_EndRequest(object sender, EventArgs e)
        {
           
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            try
            {

                //session workflow
                bool sessionReseted = false;
                if (ShopContext.Current["Shop.SessionReseted"] != null)
                {
                    sessionReseted = Convert.ToBoolean(ShopContext.Current["Shop.SessionReseted"]);
                }
                if (!sessionReseted)
                {
                    ShopContext.Current.SessionSaveToClient();
                }
            }
            catch (Exception exc)
            {
                //LogManager.InsertLog(LogTypeEnum.Unknown, exc.Message, exc);
                Debug.WriteLine(exc.Message);
            }
        }

        /// <summary>
        /// Handlers the PostAcquireRequestState event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handlers the PostRequestHandlerExecute event of the application
        /// </summary>        
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handlers the PreSendRequestContent event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void application_PreSendRequestContent(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handlers the ReleaseRequestState event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Initializes the ShopCommerceFilter object
        /// </summary>
        /// <param name="application">The application</param>
        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(this.Application_BeginRequest);
            application.EndRequest += new EventHandler(this.Application_EndRequest);
            application.PostAcquireRequestState += new EventHandler(this.Application_PostAcquireRequestState);
            application.ReleaseRequestState += new EventHandler(this.Application_ReleaseRequestState);
            application.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
            application.PreSendRequestContent += new EventHandler(this.application_PreSendRequestContent);
            application.PostRequestHandlerExecute += new EventHandler(this.application_PostRequestHandlerExecute);
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
        }
        #endregion
    }
}
