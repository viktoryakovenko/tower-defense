using System.Collections.Generic;

namespace Code.Infrastructure.States
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
        void Initialize(IEnumerable<IExitableState> states);
    }
}
