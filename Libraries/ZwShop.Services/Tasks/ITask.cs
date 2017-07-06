using System.Xml;

namespace ZwShop.Services.Tasks
{
    public partial interface ITask
    {
        void Execute(XmlNode node);
    }
}
