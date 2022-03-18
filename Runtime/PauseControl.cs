using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simple
{
    public class PauseControl : MonoBehaviour
    {
        public static event Action GamePaused;
        public static event Action GameResumed;

        public static bool gamePaused;

        public static void Pause()
        {
            gamePaused = true;
            Time.timeScale = 0;
            AudioListener.pause = true;
            GamePaused?.Invoke();
        }

        public static void Resume()
        {
            gamePaused = false;
            Time.timeScale = 1;
            AudioListener.pause = false;
            GameResumed?.Invoke();
        }

        private void Awake()
        {
            gamePaused = false;
            DontDestroyOnLoad(this);
        }
    }
}