using System.Collections;
using PowTask.ScriptableScripts;
using UnityEngine;

namespace PowTask.UI.Timer
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
        private IEnumerator _currentTimeSequence;

        private void Start()
        {
            gameplayDataSo.remainTime = gameplayDataSo.gameTime;
            gameplayDataSo.timer = 0;
            _currentTimeSequence = TimeCountdown();
            StartCoroutine(_currentTimeSequence);
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

        #region Events

        public void OnGameWin()
        {
            StopCoroutine(_currentTimeSequence);
        }

        public void OnGameOver()
        {
            StopCoroutine(_currentTimeSequence);
        }

        public void OnGameRestart()
        {
            gameplayDataSo.remainTime = gameplayDataSo.gameTime;
            gameplayDataSo.timer = 0;
            StartCoroutine(_currentTimeSequence);
        }

        public void OnGamePause()
        {
            StopCoroutine(_currentTimeSequence);
        }

        public void OnGameUnpause()
        {
            StartCoroutine(_currentTimeSequence);
        }

        public void OnSceneLoad()
        {
            onGameStart.Raise();
        }

        #endregion
    }
}
