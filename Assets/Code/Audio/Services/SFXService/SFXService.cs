using UnityEngine;

namespace Code.Audio.Services.SFXService
{
    public class SFXService : ISFXService
    {
        private bool _isEnabled = true;
        private float _currentVolume;

        public bool IsEnabled => _isEnabled && _currentVolume > 0;
        public float CurrentVolume => _currentVolume;

        public void SetEnabled(bool isEnabled) =>
            _isEnabled = isEnabled;

        public void SetVolume(float volume) =>
            _currentVolume = Mathf.Clamp01(volume);

        public void PlaySound(string soundId)
        {
            if (!IsEnabled) return;

            Debug.Log($"Playing sound: {soundId} at volume {_currentVolume}");
        }
    }
}
