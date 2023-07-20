using PowTask.ScriptableScripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.Gameplay.Player.Skill
{
    public class SixthSkill : MonoBehaviour
    {
        [SerializeField] private ActiveSkillDataSO activeSkillDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onSpendGold;

        private Button _skillButton;
        private float _currentFireInterval;

        private void Awake()
        {
            _skillButton = GetComponent<Button>();
            _skillButton.onClick.AddListener(ActiveSkill);
        }

        private void ActiveSkill()
        {
            if (playerDataSo.GoldAmount >= activeSkillDataSo.Price)
            {
                if (!activeSkillDataSo.IsSkillOnCooldown)
                {
                    SpendGold();
                    UseActiveSkill();
                    StartCoroutine(Cooldown());
                }
            }
        }

        private void SpendGold()
        {
            playerDataSo.GoldAmount -= activeSkillDataSo.Price;
            onSpendGold.Raise();
        }

        private void UseActiveSkill()
        {
            _currentFireInterval = playerDataSo.CurrentFireInterval;
            playerDataSo.CurrentFireInterval = 0.1f;
        }

        private IEnumerator Cooldown()
        {
            activeSkillDataSo.IsSkillOnCooldown = true;
            yield return new WaitForSeconds(activeSkillDataSo.CooldownTime);
            activeSkillDataSo.IsSkillOnCooldown = false;
            playerDataSo.CurrentFireInterval = _currentFireInterval;
            yield return new WaitForSeconds(activeSkillDataSo.CooldownTime);
            yield break;
        }
    }
}
