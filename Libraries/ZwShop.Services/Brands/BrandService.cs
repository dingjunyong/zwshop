using System;
using System.Collections.Generic;
using System.Linq;
using ZwShop.Services.Caching;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Data;
using ZwShop.Services.Infrastructure;
using ZwShop.Common.Utils;

namespace ZwShop.Services.Brands
{
    public partial class BrandService : IBrandService
    {
        #region Constants
        private const string BrandS_ALL_KEY = "Shop.Brand.all-{0}";
        private const string BrandS_BY_ID_KEY = "Shop.Brand.id-{0}";
        private const string PRODUCTBrandS_ALLBYBrandID_KEY = "Shop.productBrand.allbyBrandid-{0}-{1}";
        private const string PRODUCTBrandS_ALLBYPRODUCTID_KEY = "Shop.productBrand.allbyproductid-{0}-{1}";
        private const string PRODUCTBrandS_BY_ID_KEY = "Shop.productBrand.id-{0}";
        private const string BrandS_PATTERN_KEY = "Shop.Brand.";
        private const string PRODUCTBrandS_PATTERN_KEY = "Shop.productBrand.";
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
        public BrandService(ShopObjectContext context)
        {
            this._context = context;
            this._cacheManager = new ShopRequestCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Marks a Brand as deleted
        /// </summary>
        /// <param name="BrandId">Brand identifer</param>
        public void MarkBrandAsDeleted(int BrandId)
        {
            var Brand = GetBrandById(BrandId);
            if (Brand != null)
            {
                Brand.Deleted = true;
                UpdateBrand(Brand);
            }
        }

        /// <summary>
        /// Gets all Brands
        /// </summary>
        /// <returns>Brand collection</returns>
        public List<Brand> GetAllBrands()
        {
            bool showHidden = ShopContext.Current.IsAdmin;
            return GetAllBrands(showHidden);
        }

        /// <summary>
        /// Gets all Brands
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Brand collection</returns>
        public List<Brand> GetAllBrands(bool showHidden)
        {
            //string key = string.Format(BrandS_ALL_KEY, showHidden);
            //object obj2 = _cacheManager.Get(key);
            //if (this.BrandsCacheEnabled && (obj2 != null))
            //{
            //    return (List<Brand>)obj2;
            //}

            
            //var query = from m in _context.Brands
            //            orderby m.DisplayOrder
            //            where (showHidden || m.Published) &&
            //            !m.Deleted
            //            select m;
            //var Brands = query.ToList();

            //if (this.BrandsCacheEnabled)
            //{
            //    _cacheManager.Add(key, Brands);
            //}
            //return Brands;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a Brand
        /// </summary>
        /// <param name="BrandId">Brand identifier</param>
        /// <returns>Brand</returns>
        public Brand GetBrandById(int BrandId)
        {
            //if (BrandId == 0)
            //    return null;

            //string key = string.Format(BrandS_BY_ID_KEY, BrandId);
            //object obj2 = _cacheManager.Get(key);
            //if (this.BrandsCacheEnabled && (obj2 != null))
            //{
            //    return (Brand)obj2;
            //}

            
            //var query = from m in _context.Brands
            //            where m.BrandId == BrandId
            //            select m;
            //var Brand = query.SingleOrDefault();

            //if (this.BrandsCacheEnabled)
            //{
            //    _cacheManager.Add(key, Brand);
            //}
            //return Brand;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a Brand
        /// </summary>
        /// <param name="Brand">Brand</param>
        public void InsertBrand(Brand Brand)
        {
            //if (Brand == null)
            //    throw new ArgumentNullException("Brand");
            
            //Brand.Name = CommonHelper.EnsureNotNull(Brand.Name);
            //Brand.Name = CommonHelper.EnsureMaximumLength(Brand.Name, 400);
            //Brand.Description = CommonHelper.EnsureNotNull(Brand.Description);
            //Brand.MetaKeywords = CommonHelper.EnsureNotNull(Brand.MetaKeywords);
            //Brand.MetaKeywords = CommonHelper.EnsureMaximumLength(Brand.MetaKeywords, 400);
            //Brand.MetaDescription = CommonHelper.EnsureNotNull(Brand.MetaDescription);
            //Brand.MetaDescription = CommonHelper.EnsureMaximumLength(Brand.MetaDescription, 4000);
            //Brand.MetaTitle = CommonHelper.EnsureNotNull(Brand.MetaTitle);
            //Brand.MetaTitle = CommonHelper.EnsureMaximumLength(Brand.MetaTitle, 400);
            //Brand.SEName = CommonHelper.EnsureNotNull(Brand.SEName);
            //Brand.SEName = CommonHelper.EnsureMaximumLength(Brand.SEName, 100);
            //Brand.PriceRanges = CommonHelper.EnsureNotNull(Brand.PriceRanges);
            //Brand.PriceRanges = CommonHelper.EnsureMaximumLength(Brand.PriceRanges, 400);

            
            
            //_context.Brands.AddObject(Brand);
            //_context.SaveChanges();

            //if (this.BrandsCacheEnabled || this.MappingsCacheEnabled)
            //{
            //    _cacheManager.RemoveByPattern(BrandS_PATTERN_KEY);
            //    _cacheManager.RemoveByPattern(PRODUCTBrandS_PATTERN_KEY);
            //}
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Brand
        /// </summary>
        /// <param name="Brand">Brand</param>
        public void UpdateBrand(Brand Brand)
        {
            //if (Brand == null)
            //    throw new ArgumentNullException("Brand");

            //Brand.Name = CommonHelper.EnsureNotNull(Brand.Name);
            //Brand.Name = CommonHelper.EnsureMaximumLength(Brand.Name, 400);
            //Brand.Description = CommonHelper.EnsureNotNull(Brand.Description);
            //Brand.MetaKeywords = CommonHelper.EnsureNotNull(Brand.MetaKeywords);
            //Brand.MetaKeywords = CommonHelper.EnsureMaximumLength(Brand.MetaKeywords, 400);
            //Brand.MetaDescription = CommonHelper.EnsureNotNull(Brand.MetaDescription);
            //Brand.MetaDescription = CommonHelper.EnsureMaximumLength(Brand.MetaDescription, 4000);
            //Brand.MetaTitle = CommonHelper.EnsureNotNull(Brand.MetaTitle);
            //Brand.MetaTitle = CommonHelper.EnsureMaximumLength(Brand.MetaTitle, 400);
            //Brand.SEName = CommonHelper.EnsureNotNull(Brand.SEName);
            //Brand.SEName = CommonHelper.EnsureMaximumLength(Brand.SEName, 100);
            //Brand.PriceRanges = CommonHelper.EnsureNotNull(Brand.PriceRanges);
            //Brand.PriceRanges = CommonHelper.EnsureMaximumLength(Brand.PriceRanges, 400);

            
            //if (!_context.IsAttached(Brand))
            //    _context.Brands.Attach(Brand);

            //_context.SaveChanges();

            //if (this.BrandsCacheEnabled || this.MappingsCacheEnabled)
            //{
            //    _cacheManager.RemoveByPattern(BrandS_PATTERN_KEY);
            //    _cacheManager.RemoveByPattern(PRODUCTBrandS_PATTERN_KEY);
            //}
            throw new NotImplementedException();
        }

       
        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether Brands cache is enabled
        /// </summary>
        public bool BrandsCacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.BrandManager.BrandsCacheEnabled");
            }
        }

        /// <summary>
        /// Gets a value indicating whether mappings cache is enabled
        /// </summary>
        public bool MappingsCacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.BrandManager.MappingsCacheEnabled");
            }
        }
        #endregion
    }
}
