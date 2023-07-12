using UnityEngine;
using TMPro;
using PowTask.Management;
using PowTask.ScriptableScripts;
using UnityEngine.UI;

namespace PowTask.UI
{
    public class HudScreen : MonoBehaviour
    {
        // Texts
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI healthText;
        
        // Buttons
        [SerializeField] private Button loseRestartButton;
        [SerializeField] private Button loseMainMenuButton;
        [SerializeField] private Button winMainMenuButton;
        [SerializeField] private Button winRestartButton;
        [SerializeField] private Button pauseButton;
        
        // Panels
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject gameWinPanel;
        [SerializeField] private GameObject pauseMenuPanel;
        
        // SO
        [SerializeField] private GameplayDataSO gameplayDataSo;
        [SerializeField] private PlayerDataSO playerDataSo;

        // Game Event
        [SerializeField] private GameEvent onGameRestart;
        [SerializeField] private GameEvent onGamePause;
        
        // Manager
        private SceneManagement _sceneManager;
        void Start()
        {
            _sceneManager = SceneManagement.Instance;

            timerText.text = gameplayDataSo.remainTime.ToString();
            healthText.text = "Life: " + playerDataSo.PlayerBaseHealth.ToString();
            goldText.text = "Gold: " + playerDataSo.GoldAmount.ToString();

            loseRestartButton.onClick.AddListener(RestartOn);
            loseMainMenuButton.onClick.AddListener(SendBackToMainMenu);
            winRestartButton.onClick.AddListener(RestartOn);
            winMainMenuButton.onClick.AddListener(SendBackToMainMenu);
            pauseButton.onClick.AddListener(PauseTheGame);
        }

        public void OnEarnGold()
        {
            goldText.text = "Gold: " + playerDataSo.GoldAmount.ToString();
        }

        public void OnSpendGold()
        {
            goldText.text = "Gold: " + playerDataSo.GoldAmount.ToString();
        }

        public void OnPlayerHealthChange()
        {
            if (playerDataSo.PlayerHealth < 0)
            {
                healthText.text = "Life: 0";
                return;
            }
            healthText.text = "Life: " + playerDataSo.PlayerHealth;
        }
        public void OnGameWin()
        {
            gameWinPanel.SetActive(true);
        }

        public void OnGameOver()
        {
            gameOverPanel.SetActive(true);
        }

        public void OnRemainingTimeChange()
        {
            timerText.text = gameplayDataSo.remainTime.ToString();
        }

        public void OnGamePause()
        {
            gameplayDataSo.isGamePaused = true;
            pauseMenuPanel.SetActive(true);
        }

        private void PauseTheGame()
        {
            onGamePause.Raise();
        }
        private void RestartOn()
        {
            gameOverPanel.SetActive(false);
            gameWinPanel.SetActive(false);
            goldText.text = "Gold: 0";
            onGameRestart.Raise();
        }

        private void SendBackToMainMenu()
        {
            _sceneManager.LoadScene(1);
        }
    }
}
