using UnityEngine;

namespace Code.Infrastructure.Services
{
    public interface IGameObjectPool<T> where T : MonoBehaviour
    {
        bool AutoExpand { get; set; }
        T Prefab { get; }
        Transform Container { get; }
        T GetFreeElement();
        bool HasFreeElement(out T element);
    }
}
