using System.Collections.Generic;
using Code.Audio.Elements.Commands;
using Code.Audio.Services.MusicService;
using Code.Audio.Services.SFXService;
using Code.Audio.Services.VibrationService;
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
        private IMusicService _musicService;
        private IVibrationService _vibrationService;

        public void Construct(ISFXService soundService, IMusicService musicService, IVibrationService vibrationService)
        {
            _soundService = soundService;
            _musicService = musicService;
            _vibrationService = vibrationService;
        }

        public void SetupButtons()
        {
            var sliderMappings = new Dictionary<SliderHandler, ICommand<float>>
            {
                { SoundSlider, new VolumeSliderCommand(_soundService) },
                { MusicSlider, new VolumeSliderCommand(_musicService) }
            };

            SoundButton.Construct(
                new SmartSoundToggleCommand(_soundService,
                    new PlaySoundCommand(_soundService, SoundButton.GetComponent<ButtonSFX>().SoundId)
                ), _soundService);

            MusicButton.Construct(
                new CompositeCommand(new ToggleCommand(_musicService),
                    new PlaySoundCommand(_soundService, MusicButton.GetComponent<ButtonSFX>().SoundId)
                ), _musicService);

            VibrationButton.Construct(
                new CompositeCommand(new ToggleCommand(_vibrationService),
                    new PlaySoundCommand(_soundService, VibrationButton.GetComponent<ButtonSFX>().SoundId)
                ), _vibrationService);

            foreach (var pair in sliderMappings)
                pair.Key.Construct(pair.Value);
        }
    }
}
