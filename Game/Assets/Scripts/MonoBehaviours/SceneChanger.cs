using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class SceneChanger : MonoBehaviour
    {
        public string newScene;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                SceneManager.LoadScene(newScene, LoadSceneMode.Single);
            }
        }
    }
}
