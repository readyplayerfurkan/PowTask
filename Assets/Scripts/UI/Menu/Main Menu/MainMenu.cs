using PowTask.Management;
using UnityEngine;
using UnityEngine.UI;

namespace PowTask.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button loadButton;
        
        private SceneManagement sceneManagement;

        void Start()
        {
            sceneManagement = SceneManagement.Instance;
            startButton.onClick.AddListener(StartGame);
            loadButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        void StartGame()
        {
            sceneManagement.LoadScene(2);
        }

        void LoadGame()
        {
            // Load Process
        }

        void ExitGame()
        {
            Application.Quit();
            Debug.Log("Quited.");
        }
    }
}
