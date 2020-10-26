using ScriptableObjects;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using VIDE_Data;

namespace MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public UIManager2 dialogue;
        public string restartLevel = "Scene/Tutorial-Scene1";
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
            VD.Next();
            GameObject.Find("TimelineManager").GetComponent<TimelineManager>().director.Play();
        }

        public void LoadNextScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
