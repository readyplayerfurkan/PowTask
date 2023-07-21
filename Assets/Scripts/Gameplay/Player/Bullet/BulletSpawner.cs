using System.Collections;
using PowTask.Management.ObjectPooling.Abstract;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player.Bullet
{
    public class BulletSpawner : ObjectPooling<GameObject>
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        private Coroutine _fireCoroutine;
        [SerializeField] private Transform firePoint;


        private void Start()
        {
            playerDataSo.CurrentFireInterval = playerDataSo.FireInterval;
            playerDataSo.CurrentBulletAmount = playerDataSo.BulletAmount;
            playerDataSo.Damage = playerDataSo.DamageConstant;
            playerDataSo.GoldAmount = 0;
            playerDataSo.IsForthSkillActive = false;
            playerDataSo.IsPlayerCanShoot = true;
            _fireCoroutine = StartCoroutine(FireInterval());
            ObjectPool();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator FireInterval()
        {
            while (playerDataSo.IsPlayerCanShoot)
            {
                yield return new WaitForSeconds(playerDataSo.CurrentFireInterval);
                
                if (playerDataSo.IsForthSkillActive)
                {
                    yield return FireSpecial();
                }
                else
                {
                    yield return FireDefault();
                }
            }
        }

        private IEnumerator FireSpecial()
        {
            for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
            {
                playerDataSo.RotationCoef = 0;
                itemInstantiate = GetItem();
                itemInstantiate.transform.position = firePoint.transform.position;

                playerDataSo.RotationCoef = 30;
                itemInstantiate = GetItem();
                itemInstantiate.transform.position = firePoint.transform.position;

                playerDataSo.RotationCoef = -30;
                itemInstantiate = GetItem();
                itemInstantiate.transform.position = firePoint.transform.position;

                yield return new WaitForSeconds(0.1f);
            }
        }
        
        private IEnumerator FireDefault()
        {
            if (playerDataSo.IsForthSkillActive) yield break;
            
            for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
            {
                itemInstantiate = GetItem();
                itemInstantiate.transform.position = firePoint.transform.position;
                yield return new WaitForSeconds(0.1f);
            }
        }

        #region Events

        public void OnGameOver()
        {
            playerDataSo.IsPlayerCanShoot = false;
            StopCoroutine(_fireCoroutine);
        }
        public void OnGameWin()
        {
            playerDataSo.IsPlayerCanShoot = false;
            StopCoroutine(_fireCoroutine);
            playerDataSo.GoldAmount = 0;
        }

        public void OnGamePause()
        {
            playerDataSo.IsPlayerCanShoot = false;
            StopCoroutine(_fireCoroutine);
        }

        public void OnGameUnpause()
        {
            playerDataSo.IsPlayerCanShoot = true;
            StartCoroutine(FireInterval());
        }

        public void OnGameRestart()
        {
            playerDataSo.CurrentFireInterval = playerDataSo.FireInterval;
            playerDataSo.CurrentBulletAmount = playerDataSo.BulletAmount;
            playerDataSo.Damage = playerDataSo.DamageConstant;
            playerDataSo.GoldAmount = 0;
            playerDataSo.IsPlayerCanShoot = true;
            playerDataSo.IsForthSkillActive = false;
            StartCoroutine(FireInterval());
        }

        public void OnBulletDestroy(GameObject bulletInstance)
        {
            ReleaseItem(bulletInstance);
        }

        #endregion
    }
}

