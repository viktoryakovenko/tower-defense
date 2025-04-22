namespace Code.Audio.Services.SFXService
{
    public interface ISFXService : IToggleable, IVolumeControl
    {
        void PlaySound(SoundId soundId);
    }
}
