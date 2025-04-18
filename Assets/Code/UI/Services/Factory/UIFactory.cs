using System.Collections.Generic;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services;
using Code.StaticData.Windows;
using Code.UI.Elements;
using Code.UI.Elements.Commands;
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

            SetupSettingsButtons(settings);
        }

        public void CreateUIRoot()
        {
            GameObject root = _assets.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }

        private void SetupSettingsButtons(SettingsWindow settings)
        {
            var toggleMappings = new Dictionary<ToggleButtonHandler, ICommand>
            {
                { settings.SoundButton, new SoundToggleCommand(true) },
                { settings.MusicButton, new MusicToggleCommand(true) },
                { settings.VibrationButton, new SoundToggleCommand(true) },
                { settings.AdRemoveButton, new AdRemoveToggleCommand(true) }
            };

            var sliderMappings = new Dictionary<SliderHandler, ICommand>
            {
                { settings.SoundSlider, new SoundToggleCommand(true) },
                { settings.MusicSlider, new SoundToggleCommand(true) }
            };

            foreach (var pair in toggleMappings)
                pair.Key.Construct(pair.Value, true);

            foreach (var pair in sliderMappings)
                pair.Key.Construct(pair.Value);
        }
    }
}
