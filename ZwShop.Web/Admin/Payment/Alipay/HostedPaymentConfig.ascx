<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HostedPaymentConfig.ascx.cs" Inherits="ZwShop.Web.Admin.Payment.Alipay.HostedPaymentConfig" %>
<%@ Register TagPrefix="shop" TagName="DecimalTextBox" Src="../../Modules/DecimalTextBox.ascx" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Seller email:
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtSellerEmail" CssClass="adminInput" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Key:
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtKey" CssClass="adminInput" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Partner:
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtPartner" CssClass="adminInput" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Additional fee:
        </td>
        <td class="adminData">
            <shop:DecimalTextBox runat="server" ID="txtAdditionalFee" Value="0" RequiredErrorMessage="Additional fee is required"
                MinimumValue="0" MaximumValue="100000000" RangeErrorMessage="The value must be from 0 to 100,000,000"
                CssClass="adminInput"></shop:DecimalTextBox>
        </td>
    </tr>
</table>