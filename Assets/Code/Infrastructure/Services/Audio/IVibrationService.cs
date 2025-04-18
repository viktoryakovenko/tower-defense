using System;

namespace Code.Infrastructure.Services.Audio
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
