using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Data;
using ZwShop.Services.Infrastructure;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Categories
{
    public partial class CategoryService : ICategoryService
    {
        #region Constants
        private const string CATEGORIES_BY_ID_KEY = "Shop.category.id-{0}";
        private const string PRODUCTCATEGORIES_ALLBYCATEGORYID_KEY = "Shop.productcategory.allbycategoryid-{0}-{1}";
        private const string PRODUCTCATEGORIES_ALLBYPRODUCTID_KEY = "Shop.productcategory.allbyproductid-{0}-{1}";
        private const string PRODUCTCATEGORIES_BY_ID_KEY = "Shop.productcategory.id-{0}";
        private const string CATEGORIES_PATTERN_KEY = "Shop.category.";
        private const string PRODUCTCATEGORIES_PATTERN_KEY = "Shop.productcategory.";

        #endregion

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly ShopObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public CategoryService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion

        #region Methods

       
        public bool IsCategoryAccessDenied(Category category)
        {
            //if (category == null)
            //    throw new ArgumentNullException("category");

            //return category.IsAccessDenied(_context);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Marks category as deleted
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        public void MarkCategoryAsDeleted(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                category.Deleted = true;
                UpdateCategory(category);
            }
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>Categories</returns>
        public List<Category> GetAllCategories()
        {
            bool showHidden = ShopContext.Current.IsAdmin;
            return GetAllCategories(showHidden);
        }
        
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        public List<Category> GetAllCategories(bool showHidden)
        {
            
            //var query = from c in _context.Categories
            //            orderby c.ParentCategoryId, c.DisplayOrder
            //            where (showHidden || c.Published) &&
            //            !c.Deleted
            //            select c;

            ////filter by access control list (public store)
            //if (!showHidden)
            //{
            //    query = query.WhereAclPerObjectNotDenied(_context);
            //}
            //var unsortedCategories = query.ToList();

            ////sort categories
            ////TODO sort categories on database layer
            //var sortedCategories = unsortedCategories.SortCategoriesForTree(0);

            //return sortedCategories;
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets all categories by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <returns>Category collection</returns>
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        {
            bool showHidden = ShopContext.Current.IsAdmin;
            return GetAllCategoriesByParentCategoryId(parentCategoryId, showHidden);
        }
        
        /// <summary>
        /// Gets all categories filtered by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Category collection</returns>
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden)
        {
            
            //var query = from c in _context.Categories
            //            orderby c.DisplayOrder
            //            where (showHidden || c.Published) && 
            //            !c.Deleted && 
            //            c.ParentCategoryId == parentCategoryId
            //            select c;

            ////filter by access control list (public store)
            //if (!showHidden)
            //{
            //    query = query.WhereAclPerObjectNotDenied(_context);
            //}

            //var categories = query.ToList();
            //return categories;
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets all categories displayed on the home page
        /// </summary>
        /// <returns>Category collection</returns>
        public List<Category> GetAllCategoriesDisplayedOnHomePage()
        {
            //bool showHidden = ShopContext.Current.IsAdmin;

            
            //var query = from c in _context.Categories
            //            orderby c.DisplayOrder
            //            where (showHidden || c.Published) && !c.Deleted && c.ShowOnHomePage
            //            select c;

            ////filter by access control list (public store)
            //if (!showHidden)
            //{
            //    query = query.WhereAclPerObjectNotDenied(_context);
            //}

            //var categories = query.ToList();
            //return categories;
            throw new NotImplementedException();
        }
                
        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public Category GetCategoryById(int categoryId)
        {
            //if (categoryId == 0)
            //    return null;

            //string key = string.Format(CATEGORIES_BY_ID_KEY, categoryId);
            //object obj2 = _cacheManager.Get(key);
            //if (this.CategoriesCacheEnabled && (obj2 != null))
            //{
            //    return (Category)obj2;
            //}
            
            //bool showHidden = ShopContext.Current.IsAdmin;

            
            //var query = from c in _context.Categories
            //            where c.CategoryId == categoryId
            //            select c;
            //var category = query.SingleOrDefault();
            
            ////filter by access control list (public store)
            //if (category != null && !showHidden && IsCategoryAccessDenied(category))
            //{
            //    category = null;
            //}
            //if (this.CategoriesCacheEnabled)
            //{
            //    _cacheManager.Add(key, category);
            //}
            //return category;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a category breadcrumb
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public List<Category> GetBreadCrumb(int categoryId)
        {
            //var breadCrumb = new List<Category>();

            //var category = GetCategoryById(categoryId);

            //while (category != null && //category is not null
            //    !category.Deleted && //category is not deleted
            //    category.Published) //category is published
            //{
            //    breadCrumb.Add(category);
            //    category = category.ParentCategory;
            //}
            //breadCrumb.Reverse();
            //return breadCrumb;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        public void InsertCategory(Category category)
        {
            //if (category == null)
            //    throw new ArgumentNullException("category");
            
            //category.Name = CommonHelper.EnsureNotNull(category.Name);
            //category.Name = CommonHelper.EnsureMaximumLength(category.Name, 400);
            //category.Description = CommonHelper.EnsureNotNull(category.Description);
            //category.MetaKeywords = CommonHelper.EnsureNotNull(category.MetaKeywords);
            //category.MetaKeywords = CommonHelper.EnsureMaximumLength(category.MetaKeywords, 400);
            //category.MetaDescription = CommonHelper.EnsureNotNull(category.MetaDescription);
            //category.MetaDescription = CommonHelper.EnsureMaximumLength(category.MetaDescription, 4000);
            //category.MetaTitle = CommonHelper.EnsureNotNull(category.MetaTitle);
            //category.MetaTitle = CommonHelper.EnsureMaximumLength(category.MetaTitle, 400);
            //category.SEName = CommonHelper.EnsureNotNull(category.SEName);
            //category.SEName = CommonHelper.EnsureMaximumLength(category.SEName, 100);
            //category.PriceRanges = CommonHelper.EnsureNotNull(category.PriceRanges);
            //category.PriceRanges = CommonHelper.EnsureMaximumLength(category.PriceRanges, 400);

            

            //_context.Categories.AddObject(category);
            //_context.SaveChanges();

            //if (this.CategoriesCacheEnabled || this.MappingsCacheEnabled)
            //{
            //    _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            //    _cacheManager.RemoveByPattern(PRODUCTCATEGORIES_PATTERN_KEY);
            //}
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        public void UpdateCategory(Category category)
        {
            //if (category == null)
            //    throw new ArgumentNullException("category");

            //category.Name = CommonHelper.EnsureNotNull(category.Name);
            //category.Name = CommonHelper.EnsureMaximumLength(category.Name, 400);
            //category.Description = CommonHelper.EnsureNotNull(category.Description);
            //category.MetaKeywords = CommonHelper.EnsureNotNull(category.MetaKeywords);
            //category.MetaKeywords = CommonHelper.EnsureMaximumLength(category.MetaKeywords, 400);
            //category.MetaDescription = CommonHelper.EnsureNotNull(category.MetaDescription);
            //category.MetaDescription = CommonHelper.EnsureMaximumLength(category.MetaDescription, 4000);
            //category.MetaTitle = CommonHelper.EnsureNotNull(category.MetaTitle);
            //category.MetaTitle = CommonHelper.EnsureMaximumLength(category.MetaTitle, 400);
            //category.SEName = CommonHelper.EnsureNotNull(category.SEName);
            //category.SEName = CommonHelper.EnsureMaximumLength(category.SEName, 100);
            //category.PriceRanges = CommonHelper.EnsureNotNull(category.PriceRanges);
            //category.PriceRanges = CommonHelper.EnsureMaximumLength(category.PriceRanges, 400);

            ////validate category hierarchy
            //var parentCategory = GetCategoryById(category.ParentCategoryId);
            //while (parentCategory != null)
            //{
            //    if (category.CategoryId == parentCategory.CategoryId)
            //    {
            //        category.ParentCategoryId = 0;
            //        break;
            //    }
            //    parentCategory = GetCategoryById(parentCategory.ParentCategoryId);
            //}

            
            //if (!_context.IsAttached(category))
            //    _context.Categories.Attach(category);

            //_context.SaveChanges();

            //if (this.CategoriesCacheEnabled || this.MappingsCacheEnabled)
            //{
            //    _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            //    _cacheManager.RemoveByPattern(PRODUCTCATEGORIES_PATTERN_KEY);
            //}
            throw new NotImplementedException();
        }

       
        #endregion
        
        #region Properties

        /// <summary>
        /// Gets a value indicating whether categories cache is enabled
        /// </summary>
        public bool CategoriesCacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CategoryManager.CategoriesCacheEnabled");
            }
        }
        /// <summary>
        /// Gets a value indicating whether mappings cache is enabled
        /// </summary>
        public bool MappingsCacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CategoryManager.MappingsCacheEnabled");
            }
        }
        #endregion
    }
}
