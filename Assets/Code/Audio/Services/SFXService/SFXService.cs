using System;
using Code.Audio.Services.AudioEmitterHub;
using Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Audio.Services.SFXService
{
    public class SFXService : ISFXService
    {
        public event Action<bool> ToggleChanged;

        private readonly IAudioEmittersHub _audioEmittersHub;
        private readonly IStaticDataService _dataService;

        private bool _isEnabled = true;
        private float _currentVolume;

        public bool IsEnabled => _isEnabled && _currentVolume > 0;
        public float CurrentVolume => _currentVolume;

        public SFXService(IStaticDataService dataService, IAudioEmittersHub audioEmittersHub)
        {
            _dataService = dataService;
            _audioEmittersHub = audioEmittersHub;
        }

        public void Toggle()
        {
            _isEnabled = !_isEnabled;
            ToggleChanged?.Invoke(_isEnabled);

            if (!IsEnabled)
                StopAllSounds();
        }

        public void SetVolume(float volume)
        {
            if (volume == 0)
            {
                StopAllSounds();
                _isEnabled = false;
                ToggleChanged?.Invoke(_isEnabled);
                return;
            }

            _currentVolume = Mathf.Clamp01(volume);
            _isEnabled = true;
            ToggleChanged?.Invoke(_isEnabled);

            _audioEmittersHub.SetVolumeAll(_currentVolume);
        }

        public void PlaySound(SoundId soundId)
        {
            if (!IsEnabled) return;

            var soundConfig = _dataService.ForSound(soundId);
            if (soundConfig == null || soundConfig.Clip == null) return;

            var audioEmitter = _audioEmittersHub.GetFreeElement();
            audioEmitter.Play(soundConfig.Clip, _currentVolume, soundConfig.Loop);
        }

        private void StopAllSounds() =>
            _audioEmittersHub.StopAll();
    }
}
