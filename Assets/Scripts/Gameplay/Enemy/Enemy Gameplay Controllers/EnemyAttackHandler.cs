using System;
using PowTask.Gameplay.Player;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Enemy
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO enemyDataSo;
        public Action OnHealthOver;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerHealthController>(out var playerHealthController))
            {
                playerHealthController.OnPlayerTakeDamage(enemyDataSo.EnemyDamage);
                OnHealthOver.Invoke();
            }
        }
    }
}
