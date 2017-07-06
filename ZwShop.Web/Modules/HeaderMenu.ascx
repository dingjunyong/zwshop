<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderMenu.ascx.cs" Inherits="ZwShop.Web.Modules.HeaderMenu" %>
<%@ Register TagPrefix="shop" TagName="SearchBox" Src="~/Modules/SearchBox.ascx" %>
<div class="headermenu">
    <div class="searchbox">
        <shop:SearchBox runat="server" ID="ctrlSearchBox">
        </shop:SearchBox>
    </div>
    <ul class="topmenu">
        <li><a href="<%=CommonHelper.GetStoreLocation()%>">
            首页</a> </li>
        <li><a href="<%=Page.ResolveUrl("~/contactus.aspx")%>">
            新手指南</a> </li>
    </ul>
</div>

