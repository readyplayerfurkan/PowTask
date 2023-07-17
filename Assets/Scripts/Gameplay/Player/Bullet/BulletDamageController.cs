using PowTask.Gameplay.Enemy;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player
{
    public class BulletDamageController : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        public GameObjectGenericGameEvent onBulletCollide;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyHealthController>(out var enemyHealthController))
            {
                enemyHealthController.DecreaseHealth(playerDataSo.Damage);
                onBulletCollide.Raise(gameObject);
            }
        }
    }
}
