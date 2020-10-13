using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class SceneChanger : MonoBehaviour
    {
        public string newScene;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene(newScene, LoadSceneMode.Single);
        }
    }
}
