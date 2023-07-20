using System;
using PowTask.Gameplay.Player.Health;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Enemy.EnemyController
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO enemyDataSo;
        public Action onHealthOver;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerHealthController>(out var playerHealthController))
            {
                playerHealthController.OnPlayerTakeDamage(enemyDataSo.EnemyDamage);
                onHealthOver.Invoke();
            }
        }
    }
}
