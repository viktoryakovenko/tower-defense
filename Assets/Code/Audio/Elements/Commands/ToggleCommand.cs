using Code.Audio.Services;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class ToggleCommand : ICommand
    {
        private readonly IToggleable _toggleable;

        private bool _toggleEnabled;

        public ToggleCommand(IToggleable toggleable) =>
            _toggleable = toggleable;

        public void Execute() =>
            _toggleable.Toggle();
    }
}
