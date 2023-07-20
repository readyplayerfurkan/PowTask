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
        public float rotationCoef;
        private Vector3 _tempVelocity;
        
        public void ChangeRotation(float coef)
        {
            rotationCoef = coef;
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

        #region Events

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
