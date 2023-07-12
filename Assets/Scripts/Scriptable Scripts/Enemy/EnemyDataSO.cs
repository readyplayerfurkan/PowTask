using UnityEngine;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "EnemyDataSO", menuName = "PowTask/EnemyDataSO")]
    public class EnemyDataSO : ScriptableObject
    {
        [SerializeField] private float enemyHealth;
        [SerializeField] private float enemyGameTimeHealth;
        [SerializeField] private float enemyHealthConstant;
        [SerializeField] private float enemySpeed;
        [SerializeField] private int enemyDamage;
        [SerializeField] private bool isEnemyCanMove;
        [SerializeField] private int enemyGoldAmount;
        
        public int EnemyGoldAmount => enemyGoldAmount;
        
        public float EnemyHealthConstant => enemyHealthConstant;

        public float EnemyGameTimeHealth
        {
            get => enemyGameTimeHealth;
            set => enemyGameTimeHealth = value;
        }

        public float EnemySpeed => enemySpeed;

        public int EnemyDamage => enemyDamage;

        public float EnemyHealth
        {
            get => enemyHealth;
            set => enemyHealth = value;
        }
        
        public bool IsEnemyCanMove
        {
            get => isEnemyCanMove;
            set => isEnemyCanMove = value;
        }
    }
}
