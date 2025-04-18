using Code.Infrastructure.Services;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle().NonLazy();
        }
    }
}
