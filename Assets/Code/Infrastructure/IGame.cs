using Code.Infrastructure.States;

namespace Code.Infrastructure
{
    public interface IGame
    {
        void EnterState<TState>() where TState : class, IState;
    }
}
