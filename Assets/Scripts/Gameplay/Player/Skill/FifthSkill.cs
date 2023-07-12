using PowTask.Gameplay.Enemy;
using PowTask.ScriptableScripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.Gameplay.Player
{
    public class FifthSkill : MonoBehaviour
    {
        [SerializeField] private GameplayDataSO gameplayDataSo;
        [SerializeField] private ActiveSkillDataSO activeSkillDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private GameEvent onSpendGold;
        
        private Button skillButton;

        private void Awake()
        {
            skillButton = GetComponent<Button>();
            skillButton.onClick.AddListener(ActiveSkill);
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
            Debug.Log("All active enemies are hits damage");
            foreach (Transform item in gameplayDataSo.enemyContainer)
            {
                item.GetComponent<EnemyHealthController>().DecreaseHealth(playerDataSo.Damage);
            }
        }

        IEnumerator Cooldown()
        {
            activeSkillDataSo.IsSkillOnCooldown = true;
            yield return new WaitForSeconds(activeSkillDataSo.CooldownTime * 2);
            activeSkillDataSo.IsSkillOnCooldown = false;
            yield break;
        }
    }
}
