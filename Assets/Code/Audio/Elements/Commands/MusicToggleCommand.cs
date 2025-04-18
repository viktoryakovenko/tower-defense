using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class MusicToggleCommand : ICommand
    {
        private bool _toggleEnabled;

        public MusicToggleCommand(bool toggleEnabled) =>
            _toggleEnabled = toggleEnabled;

        public void Execute() =>
            _toggleEnabled = !_toggleEnabled;
    }
}
