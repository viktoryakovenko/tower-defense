namespace Code.Audio.Services.MusicService
{
    public interface IMusicService : IToggleable
    {
        float CurrentVolume { get; }

        void SetVolume(float volume);
        void PlayMusic(string trackId);
        void StopMusic();
    }
}
