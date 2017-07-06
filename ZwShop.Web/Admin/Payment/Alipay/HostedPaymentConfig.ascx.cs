using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZwShop.Web.Admin.Payment.Alipay
{
    public partial class HostedPaymentConfig : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtSellerEmail.Text = this.SettingManager.GetSettingValue("PaymentMethod.Alipay.SellerEmail");
                txtKey.Text = this.SettingManager.GetSettingValue("PaymentMethod.Alipay.Key");
                txtPartner.Text = this.SettingManager.GetSettingValue("PaymentMethod.Alipay.Partner");
                txtAdditionalFee.Value = this.SettingManager.GetSettingValueDecimalNative("PaymentMethod.Alipay.AdditionalFee");
            }
        }

        public void Save()
        {
            this.SettingManager.SetParam("PaymentMethod.Alipay.SellerEmail", txtSellerEmail.Text);
            this.SettingManager.SetParam("PaymentMethod.Alipay.Key", txtKey.Text);
            this.SettingManager.SetParam("PaymentMethod.Alipay.Partner", txtPartner.Text);
            this.SettingManager.SetParamNative("PaymentMethod.Alipay.AdditionalFee", txtAdditionalFee.Value);
        }
    }
}