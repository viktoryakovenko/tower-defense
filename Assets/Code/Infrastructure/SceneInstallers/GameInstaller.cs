using Code.Audio.Services.MusicService;
using Code.Audio.Services.SFXService;
using Code.Audio.Services.VibrationService;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Coroutines;
using Code.Infrastructure.Services;
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
            BindStaticData();
            BindSoundServices();
            BindGameStateMachine();

            BindGame();
        }

        private void BindStaticData()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
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

        private void BindSoundServices()
        {
            Container.Bind<ISFXService>().To<SFXService>().AsSingle();
            Container.Bind<IMusicService>().To<MusicService>().AsSingle();
            Container.Bind<IVibrationService>().To<VibrationService>().AsSingle();
        }
    }
}
