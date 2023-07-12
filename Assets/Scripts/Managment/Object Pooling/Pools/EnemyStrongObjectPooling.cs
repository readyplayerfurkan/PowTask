using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Management.ObjectPooling
{
    public class EnemyStrongObjectPooling : ObjectPooling<GameObject>
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
            CreateObjectsFirstStart();
        }
        
        public void OnGameOver()
        {
            DeactiveAllObject();
            StopCoroutine(_spawnCorotuine);
        }

        public void OnGameWin()
        {
            DeactiveAllObject();
            StopCoroutine(_spawnCorotuine);
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
            switch (randomSpawnerNumber)
            {
                case 1:
                    SpawnRandomEnemyStrongXLeft();
                    break;
                case 2:
                    SpawnRandomEnemyStrongXRight();
                    break;
                case 3:
                    SpawnRandomEnemyStrongZDown();
                    break;
                case 4:
                    SpawnRandomEnemyStrongZUp();
                    break;
            }
        }
        
        private void SpawnRandomEnemyStrongXRight()
        {
            Vector3 randomPos = new Vector3(RangeX, 0, Random.Range(-RangeZ, RangeZ));

            _objectInstantiate = GetObjectFromPool();
            if (_objectInstantiate != null)
            {
                _objectPool.Dequeue();
                _objectInstantiate.transform.position = randomPos;
                _objectInstantiate.SetActive(true);
                StartCoroutine(FalseGameObject(_objectInstantiate, 5f));
            }
        }

        private void SpawnRandomEnemyStrongXLeft()
        {
            Vector3 randomPos = new Vector3(-RangeX, 0, Random.Range(-RangeZ, RangeZ));

            _objectInstantiate = GetObjectFromPool();
            if (_objectInstantiate != null)
            {
                _objectPool.Dequeue();
                _objectInstantiate.transform.position = randomPos;
                _objectInstantiate.SetActive(true);
                StartCoroutine(FalseGameObject(_objectInstantiate, 5f));
            }
        }

        private void SpawnRandomEnemyStrongZUp()
        {
            Vector3 randomPos = new Vector3(Random.Range(-RangeX,RangeX), 0, RangeZ);

            _objectInstantiate = GetObjectFromPool();
            if (_objectInstantiate != null)
            {
                _objectPool.Dequeue();
                _objectInstantiate.transform.position = randomPos;
                _objectInstantiate.SetActive(true);
                StartCoroutine(FalseGameObject(_objectInstantiate, 5f));
            }
        }                                                                             
                                                                                       
        private void SpawnRandomEnemyStrongZDown()
        {
            Vector3 randomPos = new Vector3(Random.Range(-RangeX,RangeX), 0, -RangeZ);

            _objectInstantiate = GetObjectFromPool();
            if (_objectInstantiate != null)
            {
                _objectPool.Dequeue();
                _objectInstantiate.transform.position = randomPos;
                _objectInstantiate.SetActive(true);
                StartCoroutine(FalseGameObject(_objectInstantiate, 5f));
            }
        }
    }
}
