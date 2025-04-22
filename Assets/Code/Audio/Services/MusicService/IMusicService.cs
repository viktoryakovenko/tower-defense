namespace Code.Audio.Services.MusicService
{
    public interface IMusicService : IToggleable, IVolumeControl
    {
        void PlayMusic(string trackId);
        void StopMusic();
    }
}
