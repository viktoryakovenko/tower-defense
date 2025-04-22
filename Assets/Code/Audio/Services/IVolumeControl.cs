namespace Code.Audio.Services
{
    public interface IVolumeControl
    {
        float CurrentVolume { get; }

        void SetVolume(float volume);
    }
}
