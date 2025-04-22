using Code.Audio.Services;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class SmartSoundToggleCommand : ICommand
    {
        private readonly IToggleable _toggleable;
        private readonly PlaySoundCommand _playSoundCommand;

        public SmartSoundToggleCommand(IToggleable toggleable, PlaySoundCommand playSoundCommand)
        {
            _toggleable = toggleable;
            _playSoundCommand = playSoundCommand;
        }

        public void Execute()
        {
            bool wasEnabled = _toggleable.IsEnabled;

            _toggleable.Toggle();

            if (!wasEnabled && _toggleable.IsEnabled)
                _playSoundCommand.Execute();
        }
    }
}
