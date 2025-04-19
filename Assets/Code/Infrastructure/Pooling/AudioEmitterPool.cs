using UnityEngine;

namespace Code.Infrastructure.Pooling
{
    public class AudioEmitterPool : MonoBehaviour
    {
        private void Awake() =>
            DontDestroyOnLoad(this);
    }
}
