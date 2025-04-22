using System;
using UnityEngine;

namespace Code.Audio.Services.MusicService
{
    public class MusicService : IMusicService
    {
        public event Action<bool> ToggleChanged;

        private bool _isEnabled;
        private float _currentVolume;

        public float CurrentVolume => _currentVolume;
        public bool IsEnabled => _isEnabled && _currentVolume > 0;

        public void Toggle()
        {
            _isEnabled = !_isEnabled;
            ToggleChanged?.Invoke(_isEnabled);

            if (!IsEnabled)
                StopMusic();
        }

        public void SetVolume(float volume)
        {
            if (volume == 0)
            {
                StopMusic();
                _isEnabled = false;
                ToggleChanged?.Invoke(_isEnabled);
                return;
            }

            _currentVolume = Mathf.Clamp01(volume);
            _isEnabled = true;
            ToggleChanged?.Invoke(_isEnabled);
        }

        public void PlayMusic(string trackId)
        {
            if (!IsEnabled) return;

            Debug.Log("PLAY SOME MUSIC\u266a");
        }

        public void StopMusic()
        {
            Debug.Log("MUSIC STOPPED\u266a");
        }
    }
}
