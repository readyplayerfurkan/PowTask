using PowTask.SaveLoadSystem;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onGameOverEvent;

        private PlayerData tempPlayerData = new PlayerData();
        
        private void Start()
        {
            playerDataSo.PlayerHealth = playerDataSo.PlayerBaseHealth;
        }
        
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

        public void OnGameSaved()
        {
            tempPlayerData = SaveLoadManager.CurrentSaveData.PlayerData;
            tempPlayerData.playerHealth = playerDataSo.PlayerHealth;
            SaveLoadManager.SaveGame();
        }

        public void OnGameLoaded()
        {
            SaveLoadManager.LoadGame();
            playerDataSo.PlayerHealth = tempPlayerData.playerHealth;
        }
    }
}
