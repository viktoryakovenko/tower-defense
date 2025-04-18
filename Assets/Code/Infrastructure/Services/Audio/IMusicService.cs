namespace Code.Infrastructure.Services.Audio
{
    public interface IMusicService
    {
        float Volume { get; }
        bool IsEnabled { get; }

        void SetEnabled(bool isEnabled);
        void SetVolume(float volume);
        void PlayMusic(string trackId);
        void StopMusic();
    }
}
