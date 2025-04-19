using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services.StaticData;
using Code.UI.Services.Factory;
using Code.UI.Services.Windows;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            BindFactory();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            BindMenuFactory();
        }

        private void BindMenuFactory()
        {
            Container.Bind<IMenuFactory>().To<MenuFactory>().AsSingle().NonLazy();

            var factory = Container.Resolve<IMenuFactory>();
            factory.CreateMenuHUD();
        }

        private void BindFactory()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

            var factory = Container.Resolve<IUIFactory>();
            factory.CreateUIRoot();
        }
    }
}
