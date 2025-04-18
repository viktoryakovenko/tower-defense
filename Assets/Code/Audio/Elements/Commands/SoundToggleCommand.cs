using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using Code.UI.Elements.Commands;
using UnityEngine;

namespace Code.Audio.Elements.Commands
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
