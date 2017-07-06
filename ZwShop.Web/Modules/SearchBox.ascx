<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="ZwShop.Web.Modules.SearchBox" %>
<ul>
    <li>
        <asp:TextBox ID="txtSearchTerms" runat="server" SkinID="SearchBoxText" Text="汽车" />&nbsp;
    </li>
    <li>
        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索"
            CssClass="searchboxbutton" CausesValidation="false" />
    </li>
</ul>

