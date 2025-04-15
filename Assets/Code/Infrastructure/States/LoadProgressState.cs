namespace Code.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public LoadProgressState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>(Scenes.Menu);
        }

        public void Exit()
        {
        }
    }
}
