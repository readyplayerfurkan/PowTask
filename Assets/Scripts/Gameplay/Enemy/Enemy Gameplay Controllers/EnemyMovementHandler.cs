using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Enemy
{
    public class EnemyMovementHandler : MonoBehaviour
    {
        // SO
        [SerializeField] private EnemyDataSO enemyDataSo;
        [SerializeField] private Rigidbody enemyRb;
        [SerializeField] private GameObject player;
        
        void Start()
        {
            enemyDataSo.IsEnemyCanMove = true;
        }

        private void FixedUpdate()
        {
            if (enemyDataSo.IsEnemyCanMove)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;
                enemyRb.AddForce(lookDirection * enemyDataSo.EnemySpeed * Time.deltaTime);
            }
            else
            {
                enemyRb.velocity = Vector3.zero;
            }
        }

        public void OnGameRestart()
        {
            enemyDataSo.IsEnemyCanMove = true;
        }

        public void OnGameWin()
        {
            enemyDataSo.IsEnemyCanMove = false;
        }

        public void OnGameOver()
        {
            enemyDataSo.IsEnemyCanMove = false;
        }

        public void OnGamePause()
        {
            enemyDataSo.IsEnemyCanMove = false;
        }

        public void OnGameUnpaused()
        {
            enemyDataSo.IsEnemyCanMove = true;
        }

        public void ResetVelocity()
        {
            enemyRb.velocity = Vector3.zero;
        }
    }
}
