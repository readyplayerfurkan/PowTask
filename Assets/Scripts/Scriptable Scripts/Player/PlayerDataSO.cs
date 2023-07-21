using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "PlayerDataSO", menuName = "PowTask/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        // Values Of Scriptable Object
       [SerializeField] private GameObject bulletPrefab;
       [SerializeField] private float rotationCoef;
       [SerializeField] private GameObject playerPrefab;
       [SerializeField] private Quaternion bulletRotation;
       [SerializeField] private int playerBaseHealth;
       [SerializeField] private int playerHealth;
       [SerializeField] private float damage;
       [SerializeField] private float damageConstant;
       [SerializeField] private float fireInterval;
       [SerializeField] private float currentFireInterval;
       [SerializeField] private int bulletAmount;
       [SerializeField] private int currentBulletAmount;
       [SerializeField] private bool isForthSkillActive;
       [SerializeField] private int goldAmount;
       
       // Events
        [SerializeField] private GameEvent onPlayerHealthChange;

        #region Properties

        public float RotationCoef
        {
            get => rotationCoef;
            set => rotationCoef = value;
        }
        
        public int PlayerHealth
        {
            get => playerHealth;
            set
            {
                playerHealth = value;
                onPlayerHealthChange.Raise();
            }
        }
        public GameObject BulletPrefab
        {
            get => bulletPrefab;
            set => bulletPrefab = value;
        }
        public GameObject PlayerPrefab
        {
            get => playerPrefab;
            set => playerPrefab = value;
        }

        public Quaternion BulletRotation
        {
            get => bulletRotation;
            set => bulletRotation = value;
        }

        public int PlayerBaseHealth
        {
            get => playerBaseHealth;
            set => playerBaseHealth = value;
        }

        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        public float DamageConstant
        {
            get => damageConstant;
        }

        public float FireInterval
        {
            get => fireInterval;
        }

        public float CurrentFireInterval
        {
            get => currentFireInterval;
            set => currentFireInterval = value;
        }

        public int BulletAmount
        {
            get => bulletAmount;
        }

        public int CurrentBulletAmount
        {
            get => currentBulletAmount;
            set => currentBulletAmount = value;
        }

        public bool IsForthSkillActive
        {
            get => isForthSkillActive;
            set => isForthSkillActive = value;
        }
        
        public int GoldAmount
        {
            get => goldAmount;
            set => goldAmount = value;
        }

        #endregion
    }
}
