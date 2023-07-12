using PowTask.ScriptableScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.Gameplay.Player
{
    public class FirstSkill : MonoBehaviour
    {
        [SerializeField] private PasiveSkillDataSO pasiveSkillDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onSpendGold;
        private Button skillButton;

        private void Awake()
        {
            skillButton = GetComponent<Button>();
            pasiveSkillDataSo.CurrentSkillLevel = 0;
            skillButton.onClick.AddListener(IncreaseSkillLevel);
        }

        public void OnGameRestart()
        {
            pasiveSkillDataSo.CurrentSkillLevel = 0;
        }

        private void IncreaseSkillLevel()
        {
            if (pasiveSkillDataSo.CurrentSkillLevel >= pasiveSkillDataSo.MaxSkillLevel) return;

            if (playerDataSo.GoldAmount > pasiveSkillDataSo.PriceList[pasiveSkillDataSo.CurrentSkillLevel])
            {
                SpendGold();
                pasiveSkillDataSo.CurrentSkillLevel++;
                UsePasiveSkill();
                Debug.Log("First Skill level: " + pasiveSkillDataSo.CurrentSkillLevel);
            }
        }

        private void SpendGold()
        {
            playerDataSo.GoldAmount -= pasiveSkillDataSo.PriceList[pasiveSkillDataSo.CurrentSkillLevel];
            onSpendGold.Raise();
        }

        private void UsePasiveSkill()
        {
            playerDataSo.CurrentFireInterval -= 0.1f;
        }

    }
}
