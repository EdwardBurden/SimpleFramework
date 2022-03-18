using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Simple
{
    public class SceneController : MonoBehaviour
    {
        public string gameSceneName;
        public string mainMenuSceneName;

        private static SceneController instance;
        public static SceneController Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("SimpleUIController Destroyed");
                }
                return instance;
            }
        }

        internal void CloseGameScene()
        {
            SceneManager.UnloadSceneAsync(gameSceneName);
        }

        internal void CloseMainMenuScene()
        {
            SceneManager.UnloadSceneAsync(mainMenuSceneName);
        }

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        public void OpenMainMenuScene()
        {
            SceneLoader.allScenesLoaded += OnSceneLoaded;
            OpenNewScene(mainMenuSceneName);
        }

        public void OpenGameScene()
        {
            SceneLoader.allScenesLoaded += OnSceneLoaded;
            OpenNewScene(gameSceneName);
        }

        private void OnSceneLoaded()
        {
            SceneManager.UnloadSceneAsync("Loading");
            SceneLoader.allScenesLoaded -= OnSceneLoaded;
        }

        private void OpenNewScene(string sceneName)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
#if DEBUG
                string output = (string.Format("{0} Missing in {1}", ObjectNames.NicifyVariableName(sceneName), nameof(SceneController)));
                Debug.LogError(output);
#endif
                return;
            }
            SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
            SceneLoader.Instance.LoadNewScene(sceneName);
        }


    }
}