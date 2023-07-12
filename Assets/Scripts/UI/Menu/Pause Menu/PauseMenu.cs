using PowTask.ScriptableScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.UI.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        // Buttons
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private Button exitButton;
        
        // Game Events
        [SerializeField] private GameEvent onGameUnpaused;
        [SerializeField] private GameEvent onGameSaved;
        [SerializeField] private GameEvent onGameLoaded;
        
        // Panels
        [SerializeField] private GameObject pauseMenuPanel;
        
        // SO
        [SerializeField] private GameplayDataSO gamePlayDataSo;

        private void Start()
        {
            resumeButton.onClick.AddListener(ResumeGame);
            saveButton.onClick.AddListener(SaveGame);
            loadButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void ResumeGame()
        {
            onGameUnpaused.Raise();
        }

        public void OnGameUnpaused()
        {
            pauseMenuPanel.SetActive(false);
            gamePlayDataSo.isGamePaused = false;
        }

        private void SaveGame()
        {
            onGameSaved.Raise();
        }

        private void LoadGame()
        {
            onGameLoaded.Raise();
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
