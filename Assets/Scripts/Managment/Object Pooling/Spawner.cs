using System;
using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowTask.Management
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameplayDataSO gameplayDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform enemyParent;
        private SceneManagement sceneManager;
        private IEnumerator spawnCorotuine;
        private float rangeX = 10.5f;
        private float rangeZ = 5.5f;

        private void Start()
        {
            gameplayDataSo.enemyContainer = enemyParent;
            gameplayDataSo.enemySpawnTime = gameplayDataSo.spawnTimeConstant;
            sceneManager = SceneManagement.Instance;
            spawnCorotuine = SpawnSequance();
            StartCoroutine(spawnCorotuine);
        }

        public void OnGameOver()
        {
            foreach (Transform enemy in enemyParent)
            {
                Destroy(enemy.gameObject);
            }
            StopCoroutine(spawnCorotuine);
        }

        public void OnGameWin()
        {
            foreach (Transform enemy in enemyParent)
            {
                Destroy(enemy.gameObject);
            }
            StopCoroutine(spawnCorotuine);
        }

        public void OnGameRestart()
        {
            gameplayDataSo.enemySpawnTime = gameplayDataSo.spawnTimeConstant;
            StartCoroutine(spawnCorotuine);           
        }

        public void OnRemainingTimeChange()
        {
            gameplayDataSo.enemySpawnTime -= gameplayDataSo.spawnTimeDecreaseRate;
        }

        public void OnGamePause()
        {
            StopCoroutine(spawnCorotuine);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(spawnCorotuine);
        }

        private IEnumerator SpawnSequance()
        {
            yield return new WaitUntil(() => sceneManager.sceneType == SceneType.Game);

            if (!playerPrefab)
            {
                playerPrefab = Instantiate(playerDataSo.PlayerPrefab);
            }

            while (true)
            {
                int randomSpawnerNumber = Random.Range(1, 5);
                
                SpawnEnemies(randomSpawnerNumber);
                yield return new WaitForSeconds(gameplayDataSo.enemySpawnTime);
            }
        }

        private void SpawnEnemies(int randomSpawnerNumber)
        {
            switch (randomSpawnerNumber)
            {
                case 1:
                    SpawnRandomEnemiesXLeft();
                    break;
                case 2:
                    SpawnRandomEnemiesXRight();
                    break;
                case 3:
                    SpawnRandomEnemiesZDown();
                    break;
                case 4:
                    SpawnRandomEnemiesZUp();
                    break;
            }
        }

        private void SpawnRandomEnemiesXRight()
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 randomPos = new Vector3(rangeX, 0, Random.Range(-rangeZ, rangeZ));

            Instantiate(enemyPrefabs[randomIndex], randomPos, Quaternion.identity,enemyParent);
        }

        void SpawnRandomEnemiesXLeft()
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 randomPos = new Vector3(-rangeX, 0, Random.Range(-rangeZ, rangeZ));

            Instantiate(enemyPrefabs[randomIndex], randomPos, Quaternion.identity, enemyParent);
        }

        void SpawnRandomEnemiesZUp()
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 randomPos = new Vector3(Random.Range(-rangeX, rangeX), 0, rangeZ);
                                                                                       
            Instantiate(enemyPrefabs[randomIndex], randomPos, Quaternion.identity, enemyParent);    
        }                                                                              
                                                                                       
        void SpawnRandomEnemiesZDown()                                                 
        {                                                                              
            int randomIndex = Random.Range(0, enemyPrefabs.Length);        
            Vector3 randomPos = new Vector3(Random.Range(-rangeX, rangeX), 0, -rangeZ);

            Instantiate(enemyPrefabs[randomIndex], randomPos, Quaternion.identity, enemyParent);
        }
    }
}
