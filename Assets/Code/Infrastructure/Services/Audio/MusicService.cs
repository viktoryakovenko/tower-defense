namespace Code.Infrastructure.Services.Audio
{
    public class MusicService : IMusicService
    {
        public float Volume { get; }
        public bool IsEnabled { get; }

        public void SetEnabled(bool isEnabled)
        {
            throw new System.NotImplementedException();
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
