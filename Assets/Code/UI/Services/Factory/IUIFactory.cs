using System.Threading.Tasks;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory
    {
        void CreateShop();
        void CreateSettings();
        Task CreateUIRoot();
    }
}
