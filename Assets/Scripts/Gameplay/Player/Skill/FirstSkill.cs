using PowTask.ScriptableScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.Gameplay.Player.Skill
{
    public class FirstSkill : MonoBehaviour
    {
        [SerializeField] private PasiveSkillDataSO passiveSkillDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onSpendGold;
        private Button _skillButton;

        private void Awake()
        {
            _skillButton = GetComponent<Button>();
            passiveSkillDataSo.CurrentSkillLevel = 0;
            _skillButton.onClick.AddListener(IncreaseSkillLevel);
        }

        public void OnGameRestart()
        {
            passiveSkillDataSo.CurrentSkillLevel = 0;
        }

        private void IncreaseSkillLevel()
        {
            if (passiveSkillDataSo.CurrentSkillLevel >= passiveSkillDataSo.MaxSkillLevel) return;

            if (playerDataSo.GoldAmount > passiveSkillDataSo.PriceList[passiveSkillDataSo.CurrentSkillLevel])
            {
                SpendGold();
                UsePasiveSkill();
                passiveSkillDataSo.CurrentSkillLevel++;
                Debug.Log("First Skill level: " + passiveSkillDataSo.CurrentSkillLevel);
            }
        }

        private void SpendGold()
        {
            playerDataSo.GoldAmount -= passiveSkillDataSo.PriceList[passiveSkillDataSo.CurrentSkillLevel];
            onSpendGold.Raise();
        }

        private void UsePasiveSkill()
        {
            playerDataSo.CurrentFireInterval -= 0.1f;
        }
    }
}
