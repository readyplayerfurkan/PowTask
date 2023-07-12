using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask
{
    public class EnemySaveDataSO : ScriptableObject
    {
        private float _enemyGameTimeHealth;

        public float EnemyGameTimeHealth
        {
            get => _enemyGameTimeHealth;
            set => _enemyGameTimeHealth = value;
        }
    }
}
