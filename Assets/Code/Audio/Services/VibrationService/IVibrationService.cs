using System;

namespace Code.Audio.Services.VibrationService
{
    public interface IVibrationService
    {
        event Action<bool> OnVibrationEnabledChanged;

        bool IsEnabled { get; }

        void SetEnabled(bool isEnabled);
        void VibrateShort();
        void VibrateLong();
    }
}
