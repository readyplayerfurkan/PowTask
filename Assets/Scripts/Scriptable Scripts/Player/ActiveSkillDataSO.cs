using UnityEngine;
using UnityEngine.UI;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "ActiveSkillDataSO", menuName = "PowTask/ActiveSkillDataSO")]
    public class ActiveSkillDataSO : ScriptableObject
    {
        [SerializeField] private int price;
        [SerializeField] private float cooldownTime;
        [SerializeField] private bool isSkillOnCooldown;

        public int Price => price;
        public float CooldownTime => cooldownTime;

        public bool IsSkillOnCooldown
        {
            get => isSkillOnCooldown;
            set => isSkillOnCooldown = value;
        }
        
    }
}
