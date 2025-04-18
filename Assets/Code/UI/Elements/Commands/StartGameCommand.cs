using Code.Infrastructure.Commands;
using Code.Infrastructure.States;

namespace Code.UI.Elements.Commands
{
    public class StartGameCommand : ICommand
    {
        private readonly IGameStateMachine _stateMachine;

        public StartGameCommand(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Execute() =>
            StartGame();

        private void StartGame() =>
            _stateMachine.Enter<LoadLevelState, string>(Scenes.Gameplay);
    }
}
