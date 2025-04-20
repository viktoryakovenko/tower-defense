using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class SmartSFXToggleCommand : ICommand
    {
        private readonly ISFXService _soundService;
        private readonly PlaySoundCommand _playSoundCommand;

        public SmartSFXToggleCommand(ISFXService soundService, PlaySoundCommand playSoundCommand)
        {
            _soundService = soundService;
            _playSoundCommand = playSoundCommand;
        }

        public void Execute()
        {
            bool wasEnabled = _soundService.IsEnabled;

            _soundService.SetEnabled(!wasEnabled);

            if (!wasEnabled && _soundService.IsEnabled);
            _playSoundCommand.Execute();
        }
    }
}
