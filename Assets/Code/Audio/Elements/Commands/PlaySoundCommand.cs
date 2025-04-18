using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using UnityEngine;

namespace Code.Audio.Elements.Commands
{
    public class PlaySoundCommand : ICommand
    {
        private readonly ISFXService _soundService;
        private readonly AudioSource _audioSource;

        public PlaySoundCommand(ISFXService soundService, AudioSource audioSource)
        {
            _soundService = soundService;
            _audioSource = audioSource;
        }

        public void Execute()
        {
            bool wasEnabled = _soundService.IsEnabled;

            _soundService.SetEnabled(!wasEnabled);

            if (!wasEnabled && _soundService.IsEnabled)
                _soundService.PlaySound(SoundId.Click, _audioSource);
        }
    }
}
