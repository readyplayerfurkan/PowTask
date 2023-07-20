using System;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Enemy.EnemyHealth
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO enemyDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameplayDataSO gameplayDataSo;
        [SerializeField] private GameEvent onEarnGold;
        public Action onHealthOver;
        private float _health;

        public void DecreaseHealth(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                EarnGold();
                onHealthOver.Invoke();
            }
        }

        private void OnEnable()
        {
            enemyDataSo.EnemyHealth = enemyDataSo.EnemyGameTimeHealth;
            _health = enemyDataSo.EnemyHealth;
        }


        private void EarnGold()
        {
            playerDataSo.GoldAmount += enemyDataSo.EnemyGoldAmount;
            onEarnGold.Raise();
        }
        
        #region Events

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

        #endregion
    }
}
