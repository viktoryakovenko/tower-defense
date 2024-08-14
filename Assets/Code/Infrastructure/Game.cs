using Code.Infrastructure.States;
using Zenject;

namespace Code.Infrastructure
{
    public class Game : IInitializable, IGame
    {
        private IGameStateMachine _stateMachine;

        public Game(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        //Entry point
        public void Initialize() =>
            _stateMachine.Enter<BootstrapState>();

        public void EnterState<TState>() where TState : class, IState =>
            _stateMachine.Enter<TState>();
    }
}
