using ScriptableObjects;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public string restartLevel = "PrinceRoomScene";
        public PlayerHealthBar health;
        public InventoryUi inventoryUi;
        public PlayerState PlayerState { get; private set; }
        public Inventory inventory;
        public PlayableDirector director;

        public void OnPlayerDeath()
        {
            health.healthParent.transform.parent.gameObject.SetActive(false);
            inventoryUi.inventoryUi.transform.parent.gameObject.SetActive(false);
        }

        public void OnRestart()
        {
            health.healthParent.transform.parent.gameObject.SetActive(true);
            inventoryUi.inventoryUi.transform.parent.gameObject.SetActive(true);
            inventoryUi.ResetUi();
            PlayerState.ResetState();
        }

        public void PlayAnimation()
        {
            director.Play();
        }

        public void LoadNextScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
            inventory = ScriptableObject.CreateInstance<Inventory>();
            PlayerState = ScriptableObject.CreateInstance<PlayerState>();
        }
    }
}
