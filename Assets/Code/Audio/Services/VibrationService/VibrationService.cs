using System;

namespace Code.Audio.Services.VibrationService
{
    public class VibrationService : IVibrationService
    {
        public event Action<bool> ToggleChanged;

        public bool IsEnabled { get; }

        private bool _isEnabled = true;

        public void Toggle()
        {
            throw new NotImplementedException();
        }

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
