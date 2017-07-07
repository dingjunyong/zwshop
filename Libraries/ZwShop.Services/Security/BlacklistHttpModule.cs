using System;
using System.Web;
using ZwShop.Services.Infrastructure;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Security
{
    public partial class BlacklistHttpModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Context_BeginRequest);
        }
        private void Context_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                //exit if a request for a .net mapping that isn't a content page is made i.e. axd
                if (!CommonHelper.IsContentPageRequested())
                    return;
                //exit if a request for a .net mapping that isn't a content page is made i.e. axd
                if (!CommonHelper.IsContentPageRequested())
                    return;

                if (HttpContext.Current != null && !HttpContext.Current.Request.Url.IsLoopback)
                {
                    HttpApplication application = sender as HttpApplication;
                    var clientIp = new BannedIpAddress();
                    clientIp.Address = application.Request.UserHostAddress;
                    // On any unexpected error we let visitor to visit website
                    if (IoC.Resolve<IBlacklistService>().IsIpAddressBanned(clientIp))
                    {
                        // Blocking process

                        // for now just show error 404 - Forbidden
                        // later let the user know that his ip address/network 
                        // was banned and a reason why... this means we need an error page (aspx)
                        application.Response.StatusCode = 403;
                        application.Server.Transfer("~/BannedAddress.htm");
                        application.Response.StatusDescription = "Access is denied";
                        application.Response.End();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
