using Code.Audio.Services.MusicService;
using Code.Audio.Services.SFXService;
using Code.Audio.Services.VibrationService;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services.StaticData;
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
        private readonly ISFXService _soundService;
        private readonly IMusicService _musicService;
        private readonly IVibrationService _vibrationService;

        private Transform _uiRoot;

        public UIFactory(
            IStaticDataService staticData,
            IAssets assets,
            ISFXService soundService,
            IMusicService musicService,
            IVibrationService vibrationService)
        {
            _staticData = staticData;
            _assets = assets;
            _soundService = soundService;
            _musicService = musicService;
            _vibrationService = vibrationService;
        }

        public void CreateShop()
        {
        }

        public void CreateSettings()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Settings);
            SettingsWindow settings = Object.Instantiate(config.Prefab, _uiRoot) as SettingsWindow;

            settings.Construct(_soundService, _musicService, _vibrationService);
            settings.SetupButtons();
        }

        public void CreateUIRoot()
        {
            GameObject root = _assets.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }
    }
}
