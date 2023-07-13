using System;
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
        [SerializeField] private GameObjectGenericGameEvent onEnemyDie;
        private float _health;

        public void DecreaseHealth(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                EarnGold();
                onEnemyDie.Raise(gameObject);
            }
        }

        private void OnEnable()
        {
            enemyDataSo.EnemyHealth = enemyDataSo.EnemyGameTimeHealth;
            _health = enemyDataSo.EnemyHealth;
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
