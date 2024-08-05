using Code.Infrastructure.Services;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle().NonLazy();
        }
    }
}
