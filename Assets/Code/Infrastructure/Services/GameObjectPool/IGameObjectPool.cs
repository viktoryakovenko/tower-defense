using System;
using UnityEngine;

namespace Code.Infrastructure.Services.GameObjectPool
{
    public interface IGameObjectPool<T> where T : MonoBehaviour
    {
        bool AutoExpand { get; set; }
        T Prefab { get; }
        Transform Container { get; }
        T GetFreeElement(Action<T> onGetAction = null);
        bool HasFreeElement(out T element);
    }
}
