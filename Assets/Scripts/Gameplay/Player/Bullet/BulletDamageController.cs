using PowTask.Gameplay.Enemy.EnemyHealth;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player.Bullet
{
    public class BulletDamageController : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        public GameObjectGenericGameEvent onBulletDestroy;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyHealthController>(out var enemyHealthController))
            {
                enemyHealthController.DecreaseHealth(playerDataSo.Damage);
                onBulletDestroy.Raise(gameObject);
            }
        }
    }
}
