using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class GameOver : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene(GameManager.Instance.restartLevel);
            GameManager.Instance.OnRestart();
        }
    }
}
