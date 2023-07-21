using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletMovementHandler : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private Rigidbody bulletRb;
        [SerializeField] private GameObjectGenericGameEvent onBulletDestroy;
        private Vector3 _tempVelocity;
        
        private void OnEnable()
        {
            Vector3 rotation = playerDataSo.BulletRotation.eulerAngles;
            rotation.y += playerDataSo.RotationCoef;
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

        #region Events

        public void OnGameStart()
        {
            playerDataSo.RotationCoef = 0;
        }

        public void OnGameRestart()
        {
            playerDataSo.RotationCoef = 0;
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

        #endregion
    }
}
