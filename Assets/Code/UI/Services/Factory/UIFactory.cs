using System.Collections.Generic;
using Code.Audio.Elements.Commands;
using Code.Audio.Services.SFXService;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Commands;
using Code.Infrastructure.Services;
using Code.StaticData.Windows;
using Code.UI.Elements;
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

        private Transform _uiRoot;

        public UIFactory(IStaticDataService staticData, IAssets assets, ISFXService soundService)
        {
            _staticData = staticData;
            _assets = assets;
            _soundService = soundService;
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
                { settings.SoundButton, new CompositeCommand(new SoundToggleCommand(_soundService), new PlaySoundCommand(_soundService, settings.MusicButton.AudioSource)) },
                { settings.MusicButton, new MusicToggleCommand(true) },
            };

            var sliderMappings = new Dictionary<SliderHandler, ICommand<float>>
            {
                { settings.SoundSlider, new SoundSliderCommand(_soundService) },
                { settings.MusicSlider, new SoundSliderCommand(_soundService) }
            };

            foreach (var pair in toggleMappings)
                pair.Key.Construct(pair.Value, true, _soundService);

            foreach (var pair in sliderMappings)
                pair.Key.Construct(pair.Value);
        }
    }
}
