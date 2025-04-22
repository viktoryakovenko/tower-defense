using System;

namespace Code.Audio.Services.VibrationService
{
    public class VibrationService : IVibrationService
    {
        public event Action<bool> ToggleChanged;

        public bool IsEnabled => _isEnabled;

        private bool _isEnabled = true;

        public void Toggle()
        {
            _isEnabled = !_isEnabled;
            ToggleChanged?.Invoke(_isEnabled);
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
