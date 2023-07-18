using System;
using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletMovementHandler : MonoBehaviour
    {
        // SO
        [SerializeField] private PlayerDataSO playerDataSo;
        
        // Instances
        [SerializeField] private Rigidbody bulletRb;
        
        // Variables
        public float rotationCoef;

        // Temp Data
        private Vector3 _tempVelocity;
        
        // Game Event
        [SerializeField] private GameObjectGenericGameEvent onBulletDestroy;

        private void OnEnable()
        {
            Vector3 rotation = playerDataSo.BulletRotation.eulerAngles;
            rotation.y += rotationCoef;
            transform.rotation = Quaternion.Euler(rotation);
            bulletRb.velocity = Vector3.zero;
            bulletRb.AddForce(transform.forward * 2f, ForceMode.Impulse);
            StartCoroutine(BulletLifeTime());
        }

        private IEnumerator BulletLifeTime()
        {
            yield return new WaitForSeconds(5f);
            onBulletDestroy.Raise(gameObject);
            yield break;
        }
        public void OnGamePause()
        {
            _tempVelocity = bulletRb.velocity;
            bulletRb.velocity = Vector3.zero;
        }

        public void OnGameUnpause()
        {
            bulletRb.velocity = _tempVelocity;
        }
    }
}
