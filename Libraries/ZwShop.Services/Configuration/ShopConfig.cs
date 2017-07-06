using System.Configuration;
using System.Web.Configuration;
using System.Xml;

namespace ZwShop.Services.Configuration
{
    public partial class ShopConfig : IConfigurationSectionHandler
    {
        #region Fields
        private static string _connectionString = "";
        private static bool _initialized;
        private static int _cookieExpires = 128;
        private static XmlNode _scheduleTasks;
        #endregion

        #region Methods
        public object Create(object parent, object configContext, XmlNode section)
        {
            XmlNode sqlServerNode = section.SelectSingleNode("SqlServer");
            if (sqlServerNode != null)
            {
                XmlAttribute attribute = sqlServerNode.Attributes["ConnectionStringName"];
                if ((attribute != null) && (WebConfigurationManager.ConnectionStrings[attribute.Value] != null))
                    _connectionString = WebConfigurationManager.ConnectionStrings[attribute.Value].ConnectionString;
            }
            
            _scheduleTasks = section.SelectSingleNode("ScheduleTasks");

            return null;
        }

        public static void Init()
        {
            if (!_initialized)
            {
                ConfigurationManager.GetSection("ShopConfig");
                _initialized = true;
            }
        }
        #endregion

        #region Properties
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public static int CookieExpires
        {
            get
            {
                return _cookieExpires;
            }
            set
            {
                _cookieExpires = value;
            }
        }
        
        public static XmlNode ScheduleTasks
        {
            get
            {
                return _scheduleTasks;
            }
            set
            {
                _scheduleTasks = value;
            }
        }
        #endregion
    }
}
