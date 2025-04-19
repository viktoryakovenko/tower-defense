using Code.Infrastructure.Services;
using Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Audio.Services.SFXService
{
    public class SFXService : ISFXService
    {
        private readonly IStaticDataService _dataService;

        private bool _isEnabled = true;
        private float _currentVolume;

        public bool IsEnabled => _isEnabled && _currentVolume > 0;
        public float CurrentVolume => _currentVolume;

        public SFXService(IStaticDataService dataService) =>
            _dataService = dataService;

        public void SetEnabled(bool isEnabled) =>
            _isEnabled = isEnabled;

        public void SetVolume(float volume) =>
            _currentVolume = Mathf.Clamp01(volume);

        public void PlaySound(SoundId soundId, AudioSource audioSource)
        {
            if (!IsEnabled) return;

            var soundConfig = _dataService.ForSound(soundId);
            if (soundConfig == null || soundConfig.Clip == null) return;

            audioSource.loop = soundConfig.Loop;
            audioSource.clip = soundConfig.Clip;
            audioSource.volume = soundConfig.Volume * _currentVolume;
            audioSource.Play();
        }
    }
}
