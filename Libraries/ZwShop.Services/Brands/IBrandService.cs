using System.Collections.Generic;

namespace ZwShop.Services.Brands
{
    public partial interface IBrandService
    {
        void MarkBrandAsDeleted(int BrandId);

        List<Brand> GetAllBrands();


        List<Brand> GetAllBrands(bool showHidden);

        Brand GetBrandById(int BrandId);

        void InsertBrand(Brand Brand);

        void UpdateBrand(Brand Brand);
    }
}
