using Code.Audio.Services;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class SmartSFXToggleCommand : ICommand
    {
        private readonly IToggleable _soundService;
        private readonly PlaySoundCommand _playSoundCommand;

        public SmartSFXToggleCommand(IToggleable soundService, PlaySoundCommand playSoundCommand)
        {
            _soundService = soundService;
            _playSoundCommand = playSoundCommand;
        }

        public void Execute()
        {
            bool wasEnabled = _soundService.IsEnabled;

            _soundService.Toggle();

            if (!wasEnabled && _soundService.IsEnabled)
                _playSoundCommand.Execute();
        }
    }
}
