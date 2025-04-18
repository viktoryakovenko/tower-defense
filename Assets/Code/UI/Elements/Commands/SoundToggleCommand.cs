using UnityEngine;

namespace Code.UI.Elements.Commands
{
    public class SoundToggleCommand : ICommand
    {
        private bool _toggleEnabled;

        public SoundToggleCommand(bool toggleEnabled)
        {
            _toggleEnabled = toggleEnabled;
        }

        public void Execute()
        {
            _toggleEnabled = !_toggleEnabled;
            Debug.Log(_toggleEnabled);
        }
    }

    public class MusicToggleCommand : ICommand
    {
        private bool _toggleEnabled;

        public MusicToggleCommand(bool toggleEnabled)
        {
            _toggleEnabled = toggleEnabled;
        }

        public void Execute()
        {
            _toggleEnabled = !_toggleEnabled;
            Debug.Log(_toggleEnabled);
        }
    }

    public class AdRemoveToggleCommand : ICommand
    {
        private bool _toggleEnabled;

        public AdRemoveToggleCommand(bool toggleEnabled)
        {
            _toggleEnabled = toggleEnabled;
        }

        public void Execute()
        {
            _toggleEnabled = !_toggleEnabled;
            // TODO: LOGIC OF REMOVING AD
        }
    }
}
