using Code.Infrastructure.Services.Audio;
using UnityEngine;

namespace Code.UI.Elements.Commands
{
    public class SoundToggleCommand : ICommand
    {
        private bool _toggleEnabled;
        private ISFXService _soundService;

        public SoundToggleCommand(ISFXService soundService)
        {
            _soundService = soundService;
            _toggleEnabled = _soundService.IsEnabled;
        }

        public void Execute()
        {
            _toggleEnabled = !_toggleEnabled;
            _soundService.SetEnabled(_toggleEnabled);
            Debug.Log(_soundService.IsEnabled);
        }
    }
}
