namespace Code.Audio.Services.SFXService
{
    public interface ISFXService : IToggleable
    {
        float CurrentVolume { get; }

        void SetVolume(float volume);
        void PlaySound(SoundId soundId);
    }
}
