<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZwShop.Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员登录</title>
</head>
<body style="background-color: #efefef;">
    <form id="form1" runat="server">
    <div class="login-block">
        <asp:Login runat="server" ID="LoginForm" TitleText="" DestinationPageUrl="~/admin/default.aspx"
            RememberMeSet="True" FailureText="登录失败">
            <LayoutTemplate>
                <table class="login-table-container">
                    <tbody>
                        <tr class="row">
                            <td class="item-name">
                                <asp:Literal runat="server" ID="lUsernameOrEmail" Text="E-Mail" />:
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="item-value">
                                <asp:TextBox ID="UserName" runat="server" CssClass="adminInput" Style="width: 200px;" />
                                <asp:RequiredFieldValidator ID="UserNameOrEmailRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="LoginForm">
                                            *
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="item-name">
                                <asp:Literal runat="server" ID="lPassword" Text="密码" />:
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="item-value">
                                <asp:TextBox ID="Password" TextMode="Password" runat="server" MaxLength="50" CssClass="adminInput"
                                    Style="width: 200px;" />
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="密码必填" ToolTip="密码必填"
                                    ValidationGroup="LoginForm">
                                            *
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="item-value">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="记住密码" />
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="message-error">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="forgot-password">
                                <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="~/passwordrecovery.aspx"
                                    Text="忘记密码"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr class="row">
                            <td>
                                <div class="buttons">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录"
                                        ValidationGroup="LoginForm" CssClass="adminButtonBlue" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>
    </form>
</body>
</html>