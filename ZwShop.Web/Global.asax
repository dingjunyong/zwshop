<%@ Application Language="C#" %>
<%@ Import Namespace="ZwShop.Services.Configuration" %>
<%@ Import Namespace="ZwShop.Services" %>
<%@ Import Namespace="ZwShop.Services.Infrastructure" %>
<%@ Import Namespace="ZwShop.Services.Utils" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    void Application_BeginRequest(object sender, EventArgs e)
    {
        ShopConfig.Init();
      
    }


    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        ShopConfig.Init();
        //initialize IoC
        IoC.InitializeWith(new DependencyResolverFactory());

        //initialize task manager
        TaskManager.Instance.Initialize(ShopConfig.ScheduleTasks);
        TaskManager.Instance.Start();
    }
    
    void Application_End(object sender, EventArgs e)
    {
        TaskManager.Instance.Stop();
    }
    
    void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex != null)
        {
            //IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.Unknown, ex.Message, ex);
        }
    }
    
</script>
