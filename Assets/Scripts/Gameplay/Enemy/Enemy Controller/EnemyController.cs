using PowTask.Gameplay.Enemy;
using UnityEngine;

namespace PowTask
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyHealthController enemyHealthController;
        [SerializeField] private EnemyMovementHandler enemyMovementHandler;
        [SerializeField] private EnemyAttackHandler enemyAttackHandler;
        [SerializeField] private GameObjectGenericGameEvent onEnemyDied;

        private void OnEnable()
        {
            enemyHealthController.OnHealthOver += Die;
            enemyAttackHandler.OnHealthOver += Die;
        }

        private void OnDisable()
        {
            enemyHealthController.OnHealthOver -= Die;
            enemyAttackHandler.OnHealthOver -= Die;
        }

        public void Die()
        {
            enemyMovementHandler.ResetVelocity();
            enemyMovementHandler.ResetPosition();
            onEnemyDied.Raise(gameObject);
        }
    }
}
