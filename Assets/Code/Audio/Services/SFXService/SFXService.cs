using Code.Audio.Elements;
using Code.Infrastructure.Services.GameObjectPool;
using Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Audio.Services.SFXService
{
    public class SFXService : ISFXService
    {
        private readonly IGameObjectPool<AudioEmitter> _audioSourcesPool;
        private readonly IStaticDataService _dataService;

        private bool _isEnabled = true;
        private float _currentVolume;

        public bool IsEnabled => _isEnabled && _currentVolume > 0;
        public float CurrentVolume => _currentVolume;

        public SFXService(IStaticDataService dataService, IGameObjectPool<AudioEmitter> audioSourcesPool)
        {
            _dataService = dataService;
            _audioSourcesPool = audioSourcesPool;
        }

        public void SetEnabled(bool isEnabled) =>
            _isEnabled = isEnabled;

        public void SetVolume(float volume) =>
            _currentVolume = Mathf.Clamp01(volume);

        public void PlaySound(SoundId soundId)
        {
            if (!IsEnabled) return;

            var soundConfig = _dataService.ForSound(soundId);
            if (soundConfig == null || soundConfig.Clip == null) return;

            var audioEmitter = _audioSourcesPool.GetFreeElement();
            audioEmitter.Play(soundConfig.Clip, soundConfig.Volume, soundConfig.Loop);
        }
    }
}
