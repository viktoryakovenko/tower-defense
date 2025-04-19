using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Infrastructure.Services.GameObjectPool
{
    public class GameObjectPool<T> : IGameObjectPool<T> where T : MonoBehaviour
    {
        public bool AutoExpand { get; set; } = false;
        public T Prefab { get; }
        public Transform Container { get; }

        private List<T> _pool;

        public GameObjectPool(T prefab, int count)
        {
            Prefab = prefab;
            Container = null;

            CreatePool(count);
        }

        public GameObjectPool(T prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        public T GetFreeElement(Action<T> onGetAction = null)
        {
            if (HasFreeElement(out T element))
            {
                onGetAction?.Invoke(element);
                return element;
            }

            if (AutoExpand)
            {
                T createdObject = CreateObject(true);
                onGetAction?.Invoke(createdObject);
                return createdObject;
            }

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");
        }

        public bool HasFreeElement(out T element)
        {
            foreach (T objectInPool in _pool)
            {
                if (!objectInPool.gameObject.activeInHierarchy)
                {
                    element = objectInPool;
                    objectInPool.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }
    }
}
