using System.Collections.Generic;
using Code.Audio.Elements.Commands;
using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using Code.UI.Elements;

namespace Code.UI.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        public ToggleButtonHandler SoundButton;
        public ToggleButtonHandler MusicButton;
        public ToggleButtonHandler VibrationButton;
        public ToggleButtonHandler AdRemoveButton;

        public SliderHandler SoundSlider;
        public SliderHandler MusicSlider;

        private ISFXService _soundService;

        public void Construct(ISFXService soundService) =>
            _soundService = soundService;

        public void SetupButtons()
        {
            var toggleMappings = new Dictionary<ToggleButtonHandler, ICommand>
            {
                { MusicButton, new CompositeCommand(new MusicToggleCommand(true), new PlaySoundCommand(_soundService, MusicButton.GetComponent<ButtonSFX>().SoundId)) },
                { VibrationButton, new CompositeCommand(new MusicToggleCommand(true), new PlaySoundCommand(_soundService, VibrationButton.GetComponent<ButtonSFX>().SoundId)) },
                { AdRemoveButton, new CompositeCommand(new MusicToggleCommand(true), new PlaySoundCommand(_soundService, AdRemoveButton.GetComponent<ButtonSFX>().SoundId)) },
            };

            var sliderMappings = new Dictionary<SliderHandler, ICommand<float>>
            {
                { SoundSlider, new SoundSliderCommand(_soundService) },
                { MusicSlider, new SoundSliderCommand(_soundService) }
            };

            SoundButton.Construct(new SmartSFXToggleCommand(_soundService, new PlaySoundCommand(_soundService, SoundButton.GetComponent<ButtonSFX>().SoundId)), _soundService);

            foreach (var pair in sliderMappings)
                pair.Key.Construct(pair.Value);
        }
    }
}
