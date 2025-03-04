using System.Threading.Tasks;

namespace Code.UI.Services.Factory
{
    public interface IUIFactory
    {
        void CreateShop();
        void CreateSettings();
        Task CreateUIRoot();
    }
}
