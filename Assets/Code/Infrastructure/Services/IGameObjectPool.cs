using System;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public interface IGameObjectPool<T> where T : MonoBehaviour
    {
        bool AutoExpand { get; set; }
        T Prefab { get; }
        Transform Container { get; }
        T GetFreeElement(Action<T> onGetAction);
        bool HasFreeElement(out T element);
    }
}
