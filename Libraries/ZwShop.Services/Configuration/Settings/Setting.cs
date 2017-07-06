namespace ZwShop.Services.Configuration.Settings
{
    public partial class Setting : BaseEntity
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
