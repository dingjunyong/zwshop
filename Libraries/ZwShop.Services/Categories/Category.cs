
using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Media;
using ZwShop.Services.Products;

namespace ZwShop.Services.Categories
{
    public partial class Category : BaseEntity
    {
        #region Properties
        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentCategoryId { get; set; }

        public int PictureId { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        #endregion


        #region Custom Properties

        public Category ParentCategory
        {
            get
            {
                return IoC.Resolve<ICategoryService>().GetCategoryById(this.ParentCategoryId);
            }
        }

        public Picture Picture
        {
            get
            {
                return IoC.Resolve<IPictureService>().GetPictureById(this.PictureId);
            }
        }

      

        #endregion


    }
}
