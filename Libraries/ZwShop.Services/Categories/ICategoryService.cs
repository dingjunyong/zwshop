using System.Collections.Generic;

namespace ZwShop.Services.Categories
{
    public partial interface ICategoryService
    {
        bool IsCategoryAccessDenied(Category category);

        void MarkCategoryAsDeleted(int categoryId);

        List<Category> GetAllCategories();
        
        List<Category> GetAllCategories(bool showHidden);
        
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden);
        
        List<Category> GetAllCategoriesDisplayedOnHomePage();
                
        Category GetCategoryById(int categoryId);

        List<Category> GetBreadCrumb(int categoryId);

        void InsertCategory(Category category);

        void UpdateCategory(Category category);
    }
}
