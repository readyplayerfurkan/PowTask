using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace PowTask.Management.ObjectPooling
{
    public abstract class ObjectPooling<T> : MonoBehaviour where T : Object 
    {
        [SerializeField] protected T objectPrefab;
        [SerializeField] protected int amountOfObject;
        protected T _objectInstantiate;
        protected Queue<T> _objectPool = new Queue<T>();

        protected void CreateObjectsFirstStart()
        {
            for (int i = 0; i < amountOfObject; i++)
            {
                _objectInstantiate = Instantiate(objectPrefab);
                _objectInstantiate.GameObject().SetActive(false);
                _objectPool.Enqueue(_objectInstantiate);
            }
        }

        protected void DeactiveAObject(T gameObj)
        {
            gameObj.GameObject().SetActive(false);
            _objectPool.Enqueue(gameObj);
        }
        
        protected T GetObjectFromPool()
        {
            foreach (T poolingObject in _objectPool)
            {
                if (!poolingObject.GameObject().activeInHierarchy)
                    return poolingObject;
            }
            return null;
        }

        protected void DeactiveAllObject()
        {
            foreach (T poolingObject in _objectPool)
            {
                if (poolingObject.GameObject().activeInHierarchy)
                {
                    poolingObject.GameObject().SetActive(false);
                    _objectPool.Enqueue(poolingObject);
                }
            }
        }

        protected IEnumerator FalseGameObject(T poolingObject,float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.GameObject().SetActive(false);
            _objectPool.Enqueue(poolingObject);
        }
    }
}