using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public string restartLevel = "PrinceRoomScene";
        public PlayerHealthBar health;
        public InventoryUi inventory;
        
        private Inventory _inventory;

        public void OnPlayerDeath()
        {
            health.healthParent.transform.parent.gameObject.SetActive(false);
            inventory.inventoryUi.transform.parent.gameObject.SetActive(false);
        }

        public void OnRestart()
        {
            health.healthParent.transform.parent.gameObject.SetActive(true);
            inventory.inventoryUi.transform.parent.gameObject.SetActive(true);
            inventory.ResetUi();
            PlayerManager.Instance.PlayerState.ResetState();
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("More than one instance of " + GetType().Name + " found!");
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
            _inventory = ScriptableObject.CreateInstance<Inventory>();
        }
    }
}
