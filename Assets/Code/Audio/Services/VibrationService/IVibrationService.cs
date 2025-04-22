namespace Code.Audio.Services.VibrationService
{
    public interface IVibrationService : IToggleable
    {
        void VibrateShort();
        void VibrateLong();
    }
}
