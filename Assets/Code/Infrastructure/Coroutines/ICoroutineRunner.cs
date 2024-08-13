using System.Collections;

namespace Code.Infrastructure.Coroutines
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
