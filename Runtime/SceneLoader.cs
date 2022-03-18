using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Simple
{
    public class SceneLoader : MonoBehaviour
    {
        private static List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        private static bool isLoading;
        public static event Action<float> updateLoadPercentage;
        public static event Action allScenesLoaded;

        private static SceneLoader instance;
        public static SceneLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("SceneLoader Destroyed");
                }
                return instance;
            }
        }

        public void LoadScenes(string[] names)
        {
            isLoading = true;
            foreach (string name in names)
            {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
                asyncOperations.Add(asyncOperation);
            }
        }

        public void LoadNewScene(string name)
        {
            isLoading = true;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            asyncOperations.Add(asyncOperation);
        }

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (!isLoading)
            {
                return;
            }

            if (isLoading && asyncOperations.Count == 0)
            {
                isLoading = false;
                allScenesLoaded?.Invoke();
                return;
            }

            float progress = 0;
            for (int i = asyncOperations.Count - 1; i >= 0; i--)
            {
                if (!asyncOperations[i].isDone)
                {
                    progress += asyncOperations[i].progress;
                }
                else
                {
                    asyncOperations.RemoveAt(i);
                }
            }


            updateLoadPercentage?.Invoke(progress);
        }

    }
}