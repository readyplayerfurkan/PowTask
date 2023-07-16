using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Management.ObjectPooling
{
    public class EnemyStrongSpawner : ObjectPooling<GameObject>
    {
        [SerializeField] private GameplayDataSO gameplayDataSo;

        private SceneManagement _sceneManager;
        private IEnumerator _spawnCorotuine;
        private const float RangeX = 10.5f;
        private const float RangeZ = 5.5f;
        
        private void Start()
        {
            gameplayDataSo.enemySpawnTime = gameplayDataSo.spawnTimeConstant;
            _sceneManager = SceneManagement.Instance;
            _spawnCorotuine = SpawnSequance();
            StartCoroutine(_spawnCorotuine);
            ObjectPool();
        }
        
        public void OnGameOver()
        {
            StopCoroutine(_spawnCorotuine);
            ReleaseAll();
        }

        public void OnGameWin()
        {
            StopCoroutine(_spawnCorotuine);
            ReleaseAll();
        }

        public void OnGameRestart()
        {
            gameplayDataSo.enemySpawnTime = gameplayDataSo.spawnTimeConstant;
            StartCoroutine(_spawnCorotuine);           
        }

        public void OnRemainingTimeChange()
        {
            gameplayDataSo.enemySpawnTime -= gameplayDataSo.spawnTimeDecreaseRate;
        }

        public void OnGamePause()
        {
            StopCoroutine(_spawnCorotuine);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(_spawnCorotuine);
        }

        public void OnEnemyDied(GameObject poolingObject)
        {
            ReleaseItem(poolingObject);
        }
        
        private IEnumerator SpawnSequance()
        {
            yield return new WaitUntil(() => _sceneManager.sceneType == SceneType.Game);

            while (true)
            {
                int randomSpawnerNumber = Random.Range(1, 5);
                SpawnEnemies(randomSpawnerNumber);
                yield return new WaitForSeconds(gameplayDataSo.enemySpawnTime);
            }
        }
        
        private void SpawnEnemies(int randomSpawnerNumber)
        {
            Vector3 randomPosXRight = new Vector3(RangeX, 0, Random.Range(-RangeZ, RangeZ));
            Vector3 randomPosXLeft = new Vector3(-RangeX, 0, Random.Range(-RangeZ, RangeZ));
            Vector3 randomPosZUp = new Vector3(Random.Range(-RangeX,RangeX), 0, RangeZ);
            Vector3 randomPosZDown = new Vector3(Random.Range(-RangeX,RangeX), 0, -RangeZ);
            
            switch (randomSpawnerNumber)
            {
                case 1:
                    SpawnEnemy(randomPosXRight);
                    break;
                case 2:
                    SpawnEnemy(randomPosXLeft);
                    break;
                case 3:
                    SpawnEnemy(randomPosZUp);
                    break;
                case 4:
                    SpawnEnemy(randomPosZDown);
                    break;
            }
        }
        
        private void SpawnEnemy(Vector3 randomPos)
        {
            _itemInstantiate = GetItem();
            _itemInstantiate.transform.position = randomPos;
        }
    }
}
