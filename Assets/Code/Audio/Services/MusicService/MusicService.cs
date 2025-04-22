using System;

namespace Code.Audio.Services.MusicService
{
    public class MusicService : IMusicService
    {
        public event Action<bool> ToggleChanged;

        public float CurrentVolume { get; }
        public bool IsEnabled { get; }

        public void Toggle()
        {
            throw new NotImplementedException();
        }

        public void SetVolume(float volume)
        {
            throw new System.NotImplementedException();
        }

        public void PlayMusic(string trackId)
        {
            throw new System.NotImplementedException();
        }

        public void StopMusic()
        {
            throw new System.NotImplementedException();
        }
    }
}
