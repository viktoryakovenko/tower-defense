using Code.Infrastructure.States;

namespace Code.UI.Elements.Commands
{
    public class StartGameCommand : CommandBase
    {
        private IGameStateMachine _stateMachine;

        public void Construct(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public override void Execute() =>
            StartGame();

        private void StartGame() =>
            _stateMachine.Enter<LoadLevelState, string>(Scenes.Gameplay);
    }
}
