using UnityEngine;
using UnityEngine.Events;

namespace PowTask
{
    public class BaseGenericGameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private BaseGenericGameEvent<T> genericGameEvent;
        [SerializeField] private UnityEvent<T> response;

        private void OnEnable()
        {
            genericGameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            genericGameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(T t)
        {
            response.Invoke(t);
        }
    }
}