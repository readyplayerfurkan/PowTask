using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Gameplay.Player
{
    public class PlayerAttackHandler : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        private IEnumerator fireCoroutine;
        [SerializeField] private Transform firePoint;

        IEnumerator FireInterval()
        {
            while (true)
            {
                yield return new WaitForSeconds(playerDataSo.CurrentFireInterval);
                yield return Fire();
            }
        }

        public void OnGameStart()
        {
            playerDataSo.CurrentFireInterval = playerDataSo.FireInterval;
            playerDataSo.CurrentBulletAmount = playerDataSo.BulletAmount;
            playerDataSo.Damage = playerDataSo.DamageConstant;
            playerDataSo.GoldAmount = 0;
            playerDataSo.IsForthSkillActive = false;
            fireCoroutine = FireInterval();
            StartCoroutine(fireCoroutine);
        }

        public void OnGameOver()
        {
            StopCoroutine(fireCoroutine);
        }
        public void OnGameWin()
        {
            StopCoroutine(fireCoroutine);
            playerDataSo.GoldAmount = 0;
        }

        public void OnGamePause()
        {
            StopCoroutine(fireCoroutine);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(fireCoroutine);
        }

        public void OnGameRestart()
        {
            playerDataSo.CurrentFireInterval = playerDataSo.FireInterval;
            playerDataSo.CurrentBulletAmount = playerDataSo.BulletAmount;
            playerDataSo.Damage = playerDataSo.DamageConstant;
            playerDataSo.GoldAmount = 0;
            playerDataSo.IsForthSkillActive = false;
            fireCoroutine = FireInterval();
            StartCoroutine(fireCoroutine);
        }

        private IEnumerator Fire()
        {
            if (playerDataSo.IsForthSkillActive)
            {
                for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
                {
                    Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    GameObject secondBullet = Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    BulletMovementHandler secondBulletMovementHandler = secondBullet.GetComponent<BulletMovementHandler>();
                    secondBulletMovementHandler.rotationCoef = 30;
                    GameObject thirdBullet = Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    BulletMovementHandler thirdBulletMovementHandler = thirdBullet.GetComponent<BulletMovementHandler>();
                    thirdBulletMovementHandler.rotationCoef = -30;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                for (int i = 0; i < playerDataSo.CurrentBulletAmount; i++)
                {
                    Instantiate(playerDataSo.BulletPrefab, firePoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }
}
