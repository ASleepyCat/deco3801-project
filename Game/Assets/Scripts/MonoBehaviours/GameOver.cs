using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class GameOver : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("Tutorial-Scene1");
            GameManager.Instance.OnRestart();
        }
    }
}
