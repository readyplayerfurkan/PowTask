using System;
using PowTask.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PowTask.Core
{
    public class Core : ManagementBase
    {
        [SerializeField] private TextMeshProUGUI loadingText;
        [SerializeField] private List<ManagementBase> Managers;
        private SceneManagement sceneManagement;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            StartCoroutine(Init());
        }

        public override IEnumerator InitProgress()
        {
           foreach (var manager in Managers)
            {
                loadingText.text = manager.name + " Loading...";
               yield return manager.Init();
            }
           sceneManagement = SceneManagement.Instance;
            sceneManagement.LoadScene(1);
        }
        
    }
}
