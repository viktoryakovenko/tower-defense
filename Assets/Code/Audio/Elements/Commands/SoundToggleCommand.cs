using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class SoundToggleCommand : ICommand
    {
        private readonly ISFXService _soundService;

        private bool _toggleEnabled;

        public SoundToggleCommand(ISFXService soundService) =>
            _soundService = soundService;

        public void Execute() =>
            _soundService.Toggle();
    }
}
