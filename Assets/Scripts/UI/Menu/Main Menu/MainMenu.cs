using PowTask.Management.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button loadButton;
        
        private SceneManagement _sceneManagement;

        private void Start()
        {
            _sceneManagement = SceneManagement.Instance;
            startButton.onClick.AddListener(StartGame);
            loadButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            _sceneManagement.LoadScene(2);
        }

        private void LoadGame()
        {
            // Load Process
        }

        private void ExitGame()
        {
            Application.Quit();
            Debug.Log("Quited.");
        }
    }
}
