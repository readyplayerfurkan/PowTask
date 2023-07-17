using System;
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
        
        void Start ()
        {
            Vector3 rotation = playerDataSo.BulletRotation.eulerAngles;
            rotation.y += rotationCoef;
            transform.rotation = Quaternion.Euler(rotation);
            bulletRb.AddForce(transform.forward * 2f, ForceMode.Impulse);
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
