namespace ZwShop.Services.CustomerManagement
{
    public partial class CustomerBestReportLine
    {
        public int CustomerId { get; set; }

        public decimal OrderTotal { get; set; }

        public int OrderCount { get; set; }
    }
}