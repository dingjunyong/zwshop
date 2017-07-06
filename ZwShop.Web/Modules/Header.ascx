<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ZwShop.Web.Modules.Header" %>

<div class="header">
    <div class="header-logo">
        <a href="<%=CommonHelper.GetStoreLocation()%>" class="logo">&nbsp; </a>
    </div>
    <div class="header-links-wrapper">
        <div class="header-links">
            <ul>
                <asp:LoginView ID="topLoginView" runat="server">
                    <AnonymousTemplate>
                        <li>
                            <a href="<%=Page.ResolveUrl("~/register.aspx")%>" class="ico-register">注册</a>
                         </li>
                        <li>
                            <a href="<%=Page.ResolveUrl("~/login.aspx")%>" class="ico-login">登录</a>
                        </li>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <li>
                            <a href="<%= SEOHelper.GetMyAccountUrl()%>" class="account"><%=Page.User.Identity.Name %></a>
                          <%--  <% if (ShopContext.Current.IsCurrentCustomerImpersonated)
                               { 
                            %>
                            <span class="impersonate">(<%=string.Format(GetLocaleResourceString("Account.ImpersonatedAs"), this.CustomerService.UsernamesEnabled ? Server.HtmlEncode(NopContext.Current.User.Username) : Server.HtmlEncode(NopContext.Current.User.Email))%>
                                -
                                <asp:LinkButton runat="server" ID="lFinishImpersonate" Text="<% $NopResources:Account.ImpersonatedAs.Finish %>"
                                    ToolTip="<% $NopResources:Account.ImpersonatedAs.Finish.Tooltip %>" OnClick="lFinishImpersonate_Click"
                                    CssClass="finish-impersonation"></asp:LinkButton>)</span>
                            <%} %>--%>
                        </li>
                        <li><a href="<%=Page.ResolveUrl("~/logout.aspx")%>" class="ico-logout">
                            注销</a> </li>
                       
                    </LoggedInTemplate>
                </asp:LoginView>
               
                <% if (ShopContext.Current.User != null && ShopContext.Current.User.IsAdmin)
                   { %>
                <li><a href="<%=Page.ResolveUrl("~/administration/")%>" class="ico-admin">管理员后台</a> </li>
                <%} %>
            </ul>
        </div>
    </div>
    
</div>