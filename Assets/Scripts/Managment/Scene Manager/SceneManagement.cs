using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PowTask.Management.SceneManagement
{
    public class SceneManagement : ManagementBase
    {
        public static SceneManagement Instance { get; private set; }
        [HideInInspector] public SceneType sceneType;
        [SerializeField] private GameEvent onGameSceneLoad;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            Instance = this;
        }

        protected override IEnumerator InitProgress()
        {
            sceneType = SceneType.LoadingScene;
            yield return new WaitForSeconds(2f);
            Debug.Log("Scene Manager loaded.");
        }     
        
        public void LoadScene(int index)
        {
            switch (index)
            {
                case 0:
                    sceneType = SceneType.LoadingScene; break;
                case 1:
                    sceneType = SceneType.Menu; break;
                case 2:
                {
                    SceneManager.sceneLoaded += OnSceneLoaded;
                    sceneType = SceneType.Game; break;
                }
            }
            SceneManager.LoadScene(index);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            onGameSceneLoad.Raise();
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public enum SceneType 
    {
        LoadingScene,
        Menu,
        Game
    }
}
