using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask.ScriptableScripts
{
    public class GameplaySaveDataSO : ScriptableObject
    {
        private float _enemySpawnTime;
        private float _spawnTimeConstant;
        private float _spawnTimeDecreaseRate;
        private int _enemyHealthChangeInterval;
        private int _remainTime;
        private int _gameTime;
        private int _timer;
        private int _enemyHealthIncreaseInterval;
        private Transform _enemyContainer;

        public float EnemySpawnTime
        {
            get => _enemySpawnTime;
            set => _enemySpawnTime = value;
        }

        public float SpawnTimeConstant
        {
            get => _spawnTimeConstant;
            set => _spawnTimeConstant = value;
        }

        public float SpawnTimeDecreaseRate
        {
            get => _spawnTimeDecreaseRate;
            set => _spawnTimeDecreaseRate = value;
        }

        public int EnemyHealthChangeInterval
        {
            get => _enemyHealthChangeInterval;
            set => _enemyHealthChangeInterval = value;
        }

        public int RemainTime
        {
            get => _remainTime;
            set => _remainTime = value;
        }

        public int GameTime
        {
            get => _gameTime;
            set => _gameTime = value;
        }

        public int Timer
        {
            get => _timer;
            set => _timer = value;
        }

        public int EnemyHealthIncreaseInterval
        {
            get => _enemyHealthIncreaseInterval;
            set => _enemyHealthIncreaseInterval = value;
        }

        public Transform EnemyContainer
        {
            get => _enemyContainer;
            set => _enemyContainer = value;
        }
    }
}
