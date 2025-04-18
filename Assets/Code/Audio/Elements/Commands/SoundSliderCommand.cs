using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using UnityEngine;

namespace Code.Audio.Elements.Commands
{
    public class SoundSliderCommand : ICommand<float>
    {
        private readonly ISFXService _soundService;

        public SoundSliderCommand(ISFXService soundService) =>
            _soundService = soundService;

        public void Execute(float volume)
        {
            _soundService.SetVolume(volume);
            Debug.Log(_soundService.CurrentVolume);
        }
    }
}
