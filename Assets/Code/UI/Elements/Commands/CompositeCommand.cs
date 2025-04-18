using System.Collections.Generic;
using System.Linq;

namespace Code.UI.Elements.Commands
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public CompositeCommand(params ICommand[] commands) =>
            _commands = commands.ToList();

        public void Execute()
        {
            foreach (var command in _commands)
                command.Execute();
        }
    }
}
