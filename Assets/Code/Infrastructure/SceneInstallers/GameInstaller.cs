using Code.Infrastructure.Coroutines;
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
        }

        private void BindLoadingCurtain()
        {
            LoadingCurtain curtainInstance = Container.InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);
            Container.Bind<LoadingCurtain>().FromInstance(curtainInstance);
        }
        private void BindCoroutineRunner()
        {
            CoroutineRunner runnerInstance = Container.InstantiatePrefabForComponent<CoroutineRunner>(_coroutineRunner);
            Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(runnerInstance);
        }
    }
}
