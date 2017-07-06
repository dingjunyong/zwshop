

using System;
using System.Globalization;
using System.Web.UI.WebControls;
using ZwShop.Web;

namespace ZwShop.Web.Admin.Modules
{
    public partial class DecimalTextBox : BaseShopAdminUserControl
    {
        protected override void OnInit(EventArgs e)
        {
            string validChars = NumberFormatInfo.CurrentInfo.NegativeSign;
            validChars += NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;            
            ftbeValue.ValidChars = validChars;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public decimal Value
        {
            get
            {
                return decimal.Parse(txtValue.Text);
            }
            set
            {
                txtValue.Text = value.ToString("G29");
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return rfvValue.ErrorMessage;
            }
            set
            {
                rfvValue.ErrorMessage = value;
            }
        }

        public string RangeErrorMessage
        {
            get
            {
                return rvValue.ErrorMessage;
            }
            set
            {
                rvValue.ErrorMessage = value;
            }
        }

        public string MinimumValue
        {
            get
            {
                return rvValue.MinimumValue;
            }
            set
            {
                rvValue.MinimumValue = value;
            }
        }

        public string MaximumValue
        {
            get
            {
                return rvValue.MaximumValue;
            }
            set
            {
                rvValue.MaximumValue = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtValue.Width;
            }
            set
            {
                txtValue.Width = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvValue.ValidationGroup;
            }
            set
            {
                txtValue.ValidationGroup = value;
                rfvValue.ValidationGroup = value;
                rvValue.ValidationGroup = value;
            }
        }

        public string CssClass
        {
            get
            {
                return txtValue.CssClass;
            }
            set
            {
                txtValue.CssClass = value;
            }
        }
    }
}
