

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.EntityClient;
using Microsoft.Practices.Unity;
using ZwShop.Services.Audit;
using ZwShop.Services.Audit.UsersOnline;
using ZwShop.Services.Categories;
using ZwShop.Services.Configuration;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Content.Blog;
using ZwShop.Services.Content.Forums;
using ZwShop.Services.Content.NewsManagement;
using ZwShop.Services.Content.Polls;
using ZwShop.Services.Content.Topics;
using ZwShop.Services.CustomerManagement;
using ZwShop.Services.Directory;
using ZwShop.Services.ExportImport;
using ZwShop.Services.Brands;
using ZwShop.Services.Media;
using ZwShop.Services.Messages;
using ZwShop.Services.Messages.SMS;
using ZwShop.Services.Orders;
using ZwShop.Services.Payment;
using ZwShop.Services.Products;
using ZwShop.Services.Products.Attributes;
using ZwShop.Services.Products.Specs;
using ZwShop.Services.Security;
using ZwShop.Services.Shipping;
using ZwShop.Services.Data;
namespace ZwShop.Services.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        #region Fields

        private readonly IUnityContainer _container;

        #endregion

        #region Ctor

        public UnityDependencyResolver()
            : this(new UnityContainer())
        {
        }
        
        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this._container = container;
            //configure container
            ConfigureContainer(this._container);
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Configure root container.Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
        protected virtual void ConfigureContainer(IUnityContainer container)
        {
            //Take into account that Types and Mappings registration could be also done using the UNITY XML configuration
            //But we prefer doing it here (C# code) because we'll catch errors at compiling time instead execution time, if any type has been written wrong.

            //Register repositories mappings
            //to be done

            //Register default cache manager            
            //container.RegisterType<ICacheManager, ShopRequestCache>(new PerExecutionContextLifetimeManager());

            //Register managers(services) mappings
            container.RegisterType<IOnlineUserService, OnlineUserService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ISearchLogService, SearchLogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICustomerActivityService, CustomerActivityService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ILogService, LogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICategoryService, CategoryService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ISettingManager, SettingManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IBlogService, BlogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IForumService, ForumService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<INewsService, NewsService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IPollService, PollService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ITopicService, TopicService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICountryService, CountryService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICurrencyService, CurrencyService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ILanguageService, LanguageService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IStateProvinceService, StateProvinceService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IExportManager, ExportManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IImportManager, ImportManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IBrandService, BrandService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IDownloadService, DownloadService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IPictureService, PictureService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ISMSService, SMSService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IMessageService, MessageService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IOrderService, OrderService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IShoppingCartService, ShoppingCartService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IPaymentService, PaymentService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICheckoutAttributeService, CheckoutAttributeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IProductAttributeService, ProductAttributeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ISpecificationAttributeService, SpecificationAttributeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IACLService, ACLService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IBlacklistService, BlacklistService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IShippingService, ShippingService>(new UnityPerExecutionContextLifetimeManager());
            
            //注册数据库连接
            InjectionConstructor connectionStringParam = new InjectionConstructor(ShopConfig.ConnectionString);
            container.RegisterType<ShopObjectContext>(new UnityPerExecutionContextLifetimeManager(), connectionStringParam);
            
           
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register instance
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Instance</param>
        public void Register<T>(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            _container.RegisterInstance(instance);
        }

        /// <summary>
        /// Inject
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="existing">Type</param>
        public void Inject<T>(T existing)
        {
            if (existing == null)
                throw new ArgumentNullException("existing");

            _container.BuildUp(existing);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="type">Type</param>
        /// <returns>Result</returns>
        public T Resolve<T>(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return (T)_container.Resolve(type);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="type">Type</param>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public T Resolve<T>(Type type, string name)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (name == null)
                throw new ArgumentNullException("name");

            return (T)_container.Resolve(type, name);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Result</returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public T Resolve<T>(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            return _container.Resolve<T>(name);
        }

        /// <summary>
        /// Resolve all
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Result</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        #endregion
    }
}
