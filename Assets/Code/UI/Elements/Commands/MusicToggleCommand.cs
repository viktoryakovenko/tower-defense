using UnityEngine;

namespace Code.UI.Elements.Commands
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
