using UnityEngine;

namespace Code.Infrastructure.Coroutines
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake() =>
            DontDestroyOnLoad(this);
    }
}
