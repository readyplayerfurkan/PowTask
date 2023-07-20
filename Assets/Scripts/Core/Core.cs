using PowTask.Management;
using System.Collections;
using System.Collections.Generic;
using PowTask.Management.SceneManagement;
using UnityEngine;
using TMPro;

namespace PowTask.Core
{
    public class Core : ManagementBase
    {
        [SerializeField] private TextMeshProUGUI loadingText;
        [SerializeField] private List<ManagementBase> managers;
        private SceneManagement _sceneManagement;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            StartCoroutine(Init());
        }

        protected override IEnumerator InitProgress()
        {
           foreach (var manager in managers)
           {
                loadingText.text = manager.name + " Loading...";
               yield return manager.Init();
           }
           _sceneManagement = SceneManagement.Instance;
            _sceneManagement.LoadScene(1);
        }
    }
}
