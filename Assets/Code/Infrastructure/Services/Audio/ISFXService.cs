namespace Code.Infrastructure.Services.Audio
{
    public interface ISFXService
    {
        bool IsEnabled { get; }
        float CurrentVolume { get; }

        void SetEnabled(bool isEnabled);
        void SetVolume(float volume);
        void PlaySound(string soundId);
    }
}
