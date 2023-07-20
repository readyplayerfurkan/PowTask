using PowTask.Gameplay.Enemy.EnemyHealth;
using UnityEngine;

namespace PowTask.Gameplay.Enemy.EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyHealthController enemyHealthController;
        [SerializeField] private EnemyMovementHandler enemyMovementHandler;
        [SerializeField] private EnemyAttackHandler enemyAttackHandler;
        [SerializeField] private GameObjectGenericGameEvent onEnemyDied;

        private void OnEnable()
        {
            enemyHealthController.onHealthOver += Die;
            enemyAttackHandler.onHealthOver += Die;
        }

        private void OnDisable()
        {
            enemyHealthController.onHealthOver -= Die;
            enemyAttackHandler.onHealthOver -= Die;
        }

        private void Die()
        {
            enemyMovementHandler.ResetVelocity();
            enemyMovementHandler.ResetPosition();
            onEnemyDied.Raise(gameObject);
        }
    }
}
