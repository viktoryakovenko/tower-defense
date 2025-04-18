using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class SoundToggleCommand : ICommand
    {
        private readonly ISFXService _soundService;

        private bool _toggleEnabled;

        public SoundToggleCommand(ISFXService soundService)
        {
            _soundService = soundService;
            _toggleEnabled = _soundService.IsEnabled;
        }

        public void Execute()
        {
            _toggleEnabled = !_toggleEnabled;
            _soundService.SetEnabled(_toggleEnabled);
        }
    }
}
