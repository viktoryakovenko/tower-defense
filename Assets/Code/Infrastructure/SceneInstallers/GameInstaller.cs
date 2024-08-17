using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Coroutines;
using Code.Infrastructure.States;
using Code.Logic;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindCoroutineRunner();
            BindSceneLoader();
            BindGameStateMachine();

            BindGame();
        }

        private void BindGame() =>
            Container.BindInterfacesAndSelfTo<Game>().AsSingle();

        private void BindLoadingCurtain() =>
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(AssetPath.CurtainPath).AsSingle();

        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(AssetPath.CoroutineRunnerPath).AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindSceneLoader() =>
            Container.Bind<SceneLoader>().AsSingle();
    }
}
