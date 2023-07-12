using UnityEngine;

namespace PowTask.SaveLoadSystem
{
    public class PlayerSaveData : ScriptableObject
    {
        public PlayerData playerSaveData = new PlayerData();
    }

    [System.Serializable]
    public struct PlayerData
    {
        public Quaternion bulletRotation;
        public int playerHealth;
        public float damage;
        public float fireInterval;
        public float currentFireInterval;
        public int bulletAmount;
        public int currentBulletAmount;
        public bool isForthSkillActive;
        public int goldAmount;
    }
}
