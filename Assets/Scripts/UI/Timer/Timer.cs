using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.Management
{
    public class Timer : MonoBehaviour
    {
        // Data SO
        [SerializeField] private GameplayDataSO gameplayDataSo;

        // Events
        [SerializeField] private GameEvent onRemainingTimeChange;
        [SerializeField] private GameEvent onGameWin;
        [SerializeField] private GameEvent onGameStart;
        
        // Variables
        private IEnumerator currentTimeSequence;

        private void Start()
        {
            Debug.LogError("Oyun başlatıldı.");

            gameplayDataSo.remainTime = gameplayDataSo.gameTime;
            gameplayDataSo.timer = 0;
            currentTimeSequence = TimeCountdown();
            StartCoroutine(currentTimeSequence);
        }

        IEnumerator TimeCountdown()
        {
            while (true)
            {
                onRemainingTimeChange.Raise();
                yield return new WaitForSeconds(1); 
                gameplayDataSo.remainTime--;

                if (gameplayDataSo.remainTime <= 0)
                {
                    onGameWin.Raise();
                }
                gameplayDataSo.timer++;

                if (gameplayDataSo.timer == gameplayDataSo.enemyHealthIncreaseInterval + 1)
                    gameplayDataSo.timer = 0;
            }
        }

        public void OnGameWin()
        {
            StopCoroutine(currentTimeSequence);
            Debug.Log("Game is finished.");
        }

        public void OnGameOver()
        {
            StopCoroutine(currentTimeSequence);
            Debug.Log("Game is finished.");
        }

        public void OnGameRestart()
        {
            gameplayDataSo.remainTime = gameplayDataSo.gameTime;
            gameplayDataSo.timer = 0;
            StartCoroutine(currentTimeSequence);
        }

        public void OnGamePause()
        {
            StopCoroutine(currentTimeSequence);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(currentTimeSequence);
        }

        public void OnSceneLoad()
        {
            onGameStart.Raise();
        }
        
    }
}
