using PowTask.Management.ObjectPooling;
using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask
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
            _fireCoroutine = StartCoroutine(FireInterval());
            ObjectPool();
        }

        public void OnGameOver()
        {
            StopCoroutine(_fireCoroutine);
        }
        public void OnGameWin()
        {
            StopCoroutine(_fireCoroutine);
            playerDataSo.GoldAmount = 0;
        }

        public void OnGamePause()
        {
            StopCoroutine(_fireCoroutine);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(FireInterval());
        }

        public void OnGameRestart()
        {
            playerDataSo.CurrentFireInterval = playerDataSo.FireInterval;
            playerDataSo.CurrentBulletAmount = playerDataSo.BulletAmount;
            playerDataSo.Damage = playerDataSo.DamageConstant;
            playerDataSo.GoldAmount = 0;
            playerDataSo.IsForthSkillActive = false;
            StartCoroutine(FireInterval());
        }

        public void OnBulletDestroy(GameObject bulletInstance)
        {
            ReleaseItem(bulletInstance);
        }
        
        private IEnumerator FireInterval()
        {
            while (true)
            {
                yield return new WaitForSeconds(playerDataSo.CurrentFireInterval);
                yield return Fire();
            }
        }
        
        private IEnumerator Fire()
        {
            if (playerDataSo.IsForthSkillActive)
            {
                for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
                {
                    // GameObject firstBullet = GetItem();
                    // firstBullet.transform.position = firePoint.position;
                    //
                    // GameObject secondBullet = GetItem();
                    // secondBullet.transform.position = firePoint.position;
                    //
                    // GameObject thirdBullet = GetItem();

                    // Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    // GameObject secondBullet = Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    // BulletMovementHandler secondBulletMovementHandler = secondBullet.GetComponent<BulletMovementHandler>();
                    // secondBulletMovementHandler.rotationCoef = 30;
                    // GameObject thirdBullet = Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    // BulletMovementHandler thirdBulletMovementHandler = thirdBullet.GetComponent<BulletMovementHandler>();
                    // thirdBulletMovementHandler.rotationCoef = -30;
                    // yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
                {
                    _itemInstantiate = GetItem();
                    _itemInstantiate.transform.position = firePoint.transform.position;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }
}
