using System;

namespace Code.Infrastructure.Services.Audio
{
    public class VibrationService : IVibrationService
    {
        public event Action<bool> OnVibrationEnabledChanged;

        private bool _isEnabled = true;

        public bool IsEnabled { get; }

        public void SetEnabled(bool isEnabled) =>
            _isEnabled = isEnabled;

        public void VibrateShort()
        {
            throw new System.NotImplementedException();
        }

        public void VibrateLong()
        {
            throw new System.NotImplementedException();
        }
    }
}
