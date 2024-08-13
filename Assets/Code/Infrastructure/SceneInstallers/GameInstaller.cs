using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.SceneInstallers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
        }

        private void BindLoadingCurtain()
        {
            LoadingCurtain curtainInstance = Container.InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);
            Container.Bind<LoadingCurtain>().FromInstance(curtainInstance);
        }
    }
}
