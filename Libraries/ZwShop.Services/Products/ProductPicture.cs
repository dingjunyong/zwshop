using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;

namespace ZwShop.Services.Products
{
    public partial class ProductPicture : BaseEntity
    {
        #region Properties
        public int ProductId { get; set; }

        public int PictureId { get; set; }

        public int DisplayOrder { get; set; }
        #endregion 
        
        #region Custom Properties

        public Picture Picture
        {
            get
            {
                return IoC.Resolve<IPictureService>().GetPictureById(this.PictureId);
            }
        }
        #endregion

        #region Navigation Properties

        public virtual Picture NpPicture { get; set; }

        public virtual Product NpProduct { get; set; }

        #endregion
    }

}
