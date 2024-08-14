using System.Collections.Generic;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Coroutines;
using Code.Infrastructure.States;
using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindCoroutineRunner();
            BindSceneLoader();
            BindGameStateMachine();
            SetupStates();

            Container.BindInterfacesAndSelfTo<Game>().AsSingle();
        }

        private void SetupStates()
        {
            List<IExitableState> states = new List<IExitableState>()
            {
                new BootstrapState(Container.Resolve<IGameStateMachine>(), Container.Resolve<SceneLoader>()),
                new LoadProgressState(Container.Resolve<IGameStateMachine>()),
                new LoadLevelState(
                    Container.Resolve<IGameStateMachine>(),
                    Container.Resolve<SceneLoader>(),
                    Container.Resolve<LoadingCurtain>()
                ),
                new GameLoopState(Container.Resolve<IGameStateMachine>())
            };

            Container.Resolve<IGameStateMachine>().Initialize(states);
        }

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
