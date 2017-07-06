using System.Collections.Generic;
using ZwShop.Services.Products;

namespace ZwShop.Services.Media
{
    public partial class Picture : BaseEntity
    {
        #region Properties

        public int PictureId { get; set; }

        public byte[] PictureBinary { get; set; }

        public string MimeType { get; set; }

        public bool IsNew { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<ProductPicture> NpProductPictures { get; set; }

        #endregion
    }
}
