using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask.ScriptableScripts
{
    [CreateAssetMenu(fileName = "PlayerDataSO", menuName = "PowTask/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        private float _rotationCoef;
        private Quaternion _bulletRotation;
        private bool _isForthSkillActive;
        private bool _isPlayerCanShoot;
        private int _goldAmount;
        [SerializeField] private int playerBaseHealth;
        [SerializeField] private int playerHealth;
        [SerializeField] private float damage;
        [SerializeField] private float damageConstant;
        [SerializeField] private float fireInterval;
        [SerializeField] private float currentFireInterval;
        [SerializeField] private int bulletAmount;
        [SerializeField] private int currentBulletAmount;
            
        // Events
        [SerializeField] private GameEvent onPlayerHealthChange;

        #region Properties

        public float RotationCoef
        {
            get => _rotationCoef;
            set => _rotationCoef = value;
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

        public Quaternion BulletRotation
        {
            get => _bulletRotation;
            set => _bulletRotation = value;
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
            get => _isForthSkillActive;
            set => _isForthSkillActive = value;
        }

        public bool IsPlayerCanShoot
        {
            get => _isPlayerCanShoot;
            set => _isPlayerCanShoot = value;
        }
        
        public int GoldAmount
        {
            get => _goldAmount;
            set => _goldAmount = value;
        }

        #endregion
    }
}
