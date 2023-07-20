using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player.Health
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onGameOverEvent;

        private void Start()
        {
            playerDataSo.PlayerHealth = playerDataSo.PlayerBaseHealth;
        }

        #region Events

        public void OnGameRestart()
        {
            playerDataSo.PlayerHealth = playerDataSo.PlayerBaseHealth;
        }

        public void OnPlayerTakeDamage(int damage)
        {
            playerDataSo.PlayerHealth -= damage;

            if (playerDataSo.PlayerHealth <= 0)
            {
                onGameOverEvent.Raise();
            }
        }

        #endregion
    }
}
