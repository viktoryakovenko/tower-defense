using Code.Audio.Elements;
using Code.Audio.Services.AudioEmitterHub;
using Code.Audio.Services.MusicService;
using Code.Audio.Services.SFXService;
using Code.Audio.Services.VibrationService;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Coroutines;
using Code.Infrastructure.Services.GameObjectPool;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.States;
using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class GameInstaller : MonoInstaller
    {
        private const string AUDIO_EMITTERS_POOL = "AudioEmitterPool";
        private const int POOL_COUNT = 10;

        [SerializeField] private AudioEmitter _audioEmitterPrefab;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindCoroutineRunner();
            BindSceneLoader();
            BindStaticData();
            BindAudioEmittersHub();
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

        private void BindAudioEmittersHub()
        {
            var go = new GameObject(AUDIO_EMITTERS_POOL);
            DontDestroyOnLoad(go);
            var parent = go.transform;

            var audioEmittersPool = new GameObjectPool<AudioEmitter>(_audioEmitterPrefab, POOL_COUNT, parent);
            audioEmittersPool.AutoExpand = true;

            Container.Bind<IGameObjectPool<AudioEmitter>>()
                .To<GameObjectPool<AudioEmitter>>()
                .FromInstance(audioEmittersPool)
                .AsSingle();

            Container.Bind<IAudioEmittersHub>().To<AudioEmittersHub>().AsSingle();
        }
    }
}
