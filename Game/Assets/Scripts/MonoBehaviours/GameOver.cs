using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class GameOver : MonoBehaviour
    {
        public delegate void OnRestart();
        public OnRestart onRestartCallback;
        
        private void Awake()
        {
            onRestartCallback = GameManager.Instance.OnRestart;
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(GameManager.Instance.restartLevel);
            onRestartCallback.Invoke();
        }
    }
}
