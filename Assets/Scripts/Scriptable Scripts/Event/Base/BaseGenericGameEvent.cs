using UnityEngine;
using System.Collections.Generic;

namespace PowTask
{
    [CreateAssetMenu]
    public class BaseGenericGameEvent<T> : ScriptableObject
    {
        private List<BaseGenericGameEventListener<T>> listeners = new List<BaseGenericGameEventListener<T>>();

        public void Raise(T t)
        {
            for (int i = listeners.Count; i >= 0; i--)
            {
                listeners[i].OnEventRaised(t);
            }
        }

        public void RegisterListener(BaseGenericGameEventListener<T> listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(BaseGenericGameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
