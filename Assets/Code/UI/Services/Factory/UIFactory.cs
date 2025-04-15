using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services;
using Code.StaticData.Windows;
using Code.UI.Services.Windows;
using Code.UI.Windows.Settings;
using UnityEngine;

namespace Code.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";

        private readonly IStaticDataService _staticData;
        private readonly IAssets _assets;

        private Transform _uiRoot;

        public UIFactory(IStaticDataService staticData, IAssets assets)
        {
            _staticData = staticData;
            _assets = assets;
        }

        public void CreateShop()
        {
        }

        public void CreateSettings()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Settings);
            SettingsWindow settings = Object.Instantiate(config.Prefab, _uiRoot) as SettingsWindow;
        }

        public void CreateUIRoot()
        {
            GameObject root = _assets.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }
    }
}
