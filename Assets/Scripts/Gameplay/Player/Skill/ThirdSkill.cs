using PowTask.Management;
using PowTask.ScriptableScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.Gameplay.Player
{
    public class ThirdSkill : MonoBehaviour
    {
        [SerializeField] private PasiveSkillDataSO pasiveSkillDataSO;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onSpendGold;

        private Button skillButton;

        private void Awake()
        {
            skillButton = GetComponent<Button>();
            pasiveSkillDataSO.CurrentSkillLevel = 0;
            skillButton.onClick.AddListener(IncreaseSkillLevel);
        }

        public void OnGameRestart()
        {
            pasiveSkillDataSO.CurrentSkillLevel = 0;
        }

        public void IncreaseSkillLevel()
        {
            if (pasiveSkillDataSO.CurrentSkillLevel >= pasiveSkillDataSO.MaxSkillLevel) return;

            if (playerDataSo.GoldAmount > pasiveSkillDataSO.PriceList[pasiveSkillDataSO.CurrentSkillLevel])
            {
                pasiveSkillDataSO.CurrentSkillLevel++;
                SpendGold();
                UsePasiveSkill();
                Debug.Log("Third Skill level: " + pasiveSkillDataSO.CurrentSkillLevel);
            }
        }
        
        private void SpendGold()
        {
            playerDataSo.GoldAmount -= pasiveSkillDataSO.PriceList[pasiveSkillDataSO.CurrentSkillLevel];
            onSpendGold.Raise();
        }

        public void UsePasiveSkill()
        {
            playerDataSo.CurrentBulletAmount++;
        }
    }
}
