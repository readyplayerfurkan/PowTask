using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowTask
{
    public class PlayerSaveDataSO : ScriptableObject
    {
        private Quaternion _bulletRotation;
        private int _playerBaseHealth;
        private int _playerHealth;
        private float _damage;
        private float _damageConstant;
        private float _fireInterval;
        private float _currentFireInterval;
        private int _bulletAmount;
        private int _currentBulletAmount;
        private bool _isForthSkillActive;
        private int _goldAmount;

        public int PlayerHealth
        {
            get => _playerHealth;
            set => _playerHealth = value;
        }

        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public float CurrentFireInterval
        {
            get => _currentFireInterval;
            set => _currentFireInterval = value;
        }

        public int CurrentBulletAmount
        {
            get => _currentBulletAmount;
            set => _currentBulletAmount = value;
        }

        public int GoldAmount
        {
            get => _goldAmount;
            set => _goldAmount = value;
        }

        public Quaternion BulletRotation
        {
            get => _bulletRotation;
            set => _bulletRotation = value;
        }

        public int PlayerBaseHealth
        {
            get => _playerBaseHealth;
            set => _playerBaseHealth = value;
        }

        public float DamageConstant
        {
            get => _damageConstant;
            set => _damageConstant = value;
        }

        public float FireInterval
        {
            get => _fireInterval;
            set => _fireInterval = value;
        }

        public bool İsForthSkillActive
        {
            get => _isForthSkillActive;
            set => _isForthSkillActive = value;
        }

        public int BulletAmount
        {
            get => _bulletAmount;
            set => _bulletAmount = value;
        }
    }
}
