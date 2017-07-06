using ZwShop.Services.Infrastructure;

namespace ZwShop.Services.Directory
{
    public partial class StateProvince : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public int DisplayOrder { get; set; }

        #endregion

      
    }

}
