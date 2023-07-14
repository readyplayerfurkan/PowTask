using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace PowTask.Management.ObjectPooling
{
    public abstract class ObjectPooling<T> : MonoBehaviour where T : Object 
    {
        [SerializeField] protected T itemPrefab;
        [SerializeField] protected int amountOfItem;
        protected T _itemInstantiate;
        protected Queue<T> _passiveObjectPool = new Queue<T>();
        protected List<T> _activeObjectPool = new List<T>();

        protected void ObjectPool()
        {
            for (int i = 0; i < amountOfItem; i++)
            {
                _itemInstantiate = Instantiate(itemPrefab);
                _itemInstantiate.GameObject().SetActive(false);
                _passiveObjectPool.Enqueue(_itemInstantiate);
            }
        }
        
        protected void ReleaseItem(T item)
        {
            if (!_activeObjectPool.Contains(item)) return;

            _activeObjectPool.Remove(item);
            item.GameObject().SetActive(false);
            _passiveObjectPool.Enqueue(item);
        }

        protected void ReleaseAll()
        {
            Debug.Log("İlk kontrol");
            Debug.Log(_activeObjectPool.Count);
            if (_activeObjectPool.Count != 0)
            {
                Debug.Log("İlk koşuldan geçildi.");
                for (int i = 0; i < _activeObjectPool.Count; i++)
                {
                    Debug.Log("ReleaseAll is triggered.");
                    ReleaseItem(_activeObjectPool[i]);
                }
            }
        }

        protected T GetItem()
        {
            T item = _passiveObjectPool.Count != 0 ? _passiveObjectPool.Dequeue() : CreateItem();
            _activeObjectPool.Add(item);
            item.GameObject().SetActive(true);
            return item;
        }
        
        protected T CreateItem()
        {
            T newItem = Instantiate(_itemInstantiate);
            return newItem;
        }
    }
}