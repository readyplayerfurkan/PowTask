using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Enemy
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO enemyDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameplayDataSO gameplayDataSo;
        [SerializeField] private GameEvent onEarnGold;
        private float _health;

        private void Start()
        {
            enemyDataSo.EnemyHealth = enemyDataSo.EnemyGameTimeHealth;
            _health = enemyDataSo.EnemyHealth;
        }

        public void DecreaseHealth(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                EarnGold();
                Destroy(gameObject);
            }
        }

        public void OnGameStart()
        {
            enemyDataSo.EnemyGameTimeHealth = enemyDataSo.EnemyHealthConstant;
        }

        public void OnGameRestart()
        {
            enemyDataSo.EnemyGameTimeHealth = enemyDataSo.EnemyHealthConstant;
        }

        public void OnRemainingTimeChange()
        {
            if (gameplayDataSo.timer != gameplayDataSo.enemyHealthIncreaseInterval) return;
           
            enemyDataSo.EnemyGameTimeHealth += gameplayDataSo.enemyHealthChangeInterval;

        }
        
        private void EarnGold()
        {
            playerDataSo.GoldAmount += enemyDataSo.EnemyGoldAmount;
            onEarnGold.Raise();
        }
        
    }
}
