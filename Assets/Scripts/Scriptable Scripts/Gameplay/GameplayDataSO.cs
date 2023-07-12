using UnityEngine;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "GameplayDataSO", menuName = "PowTask/GameplayData")]
    public class GameplayDataSO : ScriptableObject
    {
        public float enemySpawnTime;
        public float spawnTimeConstant;
        [Range(0.01f,0.03f)] public float spawnTimeDecreaseRate;
        [Range(1, 3)] public int enemyHealthChangeInterval;
        public int remainTime;
        public int gameTime;
        public int timer;
        public int enemyHealthIncreaseInterval;
        public Transform enemyContainer;
        public bool isGamePaused;
    }
}
