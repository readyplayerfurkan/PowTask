using PowTask.Gameplay.Enemy;
using PowTask.ScriptableScripts;
using UnityEngine;
using System;

namespace PowTask.Gameplay.Player
{
    public class BulletDamageController : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        public Action OnBulletCollide;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyHealthController>(out var enemyHealthController))
            {
                enemyHealthController.DecreaseHealth(playerDataSo.Damage);
                OnBulletCollide.Invoke();
            }
        }
    }
}
