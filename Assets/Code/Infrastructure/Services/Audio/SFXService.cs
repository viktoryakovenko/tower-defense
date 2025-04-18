using UnityEngine;

namespace Code.Infrastructure.Services.Audio
{
    public class SFXService : ISFXService
    {
        private bool _isEnabled = true;
        private float _currentVolume;

        public bool IsEnabled => _isEnabled;
        public float CurrentVolume => _currentVolume;

        public void SetEnabled(bool isEnabled) =>
            _isEnabled = isEnabled;

        public void SetVolume(float volume) =>
            _currentVolume = Mathf.Clamp01(volume);

        public void PlaySound(string soundId)
        {
            if (!_isEnabled) return;

            Debug.Log($"Playing sound: {soundId} at volume {_currentVolume}");
        }
    }
}
