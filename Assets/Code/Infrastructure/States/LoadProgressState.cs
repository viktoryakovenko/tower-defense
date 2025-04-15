using UnityEngine;

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
            LoadingImitation();
            _stateMachine.Enter<MainMenuState, string>(Scenes.Menu);
        }

        public void Exit()
        {
        }

        private static void LoadingImitation()
        {
            for (short i = 0; i < short.MaxValue/4; i++)
                Debug.Log(i++ + --i);
        }
    }
}
