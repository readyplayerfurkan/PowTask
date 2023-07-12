using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "PasiveSkillDataSO", menuName = "PowTask/PasiveSkillDataSO")]
    public class PasiveSkillDataSO : ScriptableObject
    {
        [SerializeField] private int currentSkillLevel;
        [SerializeField] private int maxSkillLevel;
        [SerializeField] private List<int> priceList = new List<int>();

        public int CurrentSkillLevel
        {
            get => currentSkillLevel;
            set => currentSkillLevel = value;
        }
        public int MaxSkillLevel => maxSkillLevel;
        public List<int> PriceList => priceList;
    }
    
}
