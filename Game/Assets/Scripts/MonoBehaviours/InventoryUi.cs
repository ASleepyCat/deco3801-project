using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class InventoryUi : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject inventoryUi;
        public Text itemDescription;

        private Inventory _inventory; // Cached reference to inventory singleton
        private InventorySlot[] _slots;
        private PlayerManager _playerManager;

        /// <summary>
        /// Toggles the UI off and clears all the slots.
        /// </summary>
        public void ResetUi()
        {
            inventoryUi.SetActive(false);
            foreach (var slot in _slots)
                slot.ClearSlot();
        }
        
        private void Start()
        {
            if (GameManager.Instance.inventory != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            GameManager.Instance.inventory = this;
            _inventory = Inventory.Instance;
            _inventory.ONItemAddedCallback = UpdateUi;
            _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
            _playerManager = PlayerManager.Instance;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                var inventoryOpen = inventoryUi.activeSelf;
                var state = !inventoryOpen
                    ? PlayerState.States.InInventory
                    : PlayerState.States.Free;
                Debug.Log(String.Format("open {0} state {1}", inventoryOpen, state));
                if (_playerManager.PlayerState.SetPlayerState(state))
                    inventoryUi.SetActive(!inventoryOpen);
            }
        }

        /// <summary>
        /// Updates the inventory UI whenever an item is added to player's inventory.
        /// </summary>
        private void UpdateUi()
        {
            Debug.Log("update UI callback");
            for (var slot = 0; slot < _slots.Length; ++slot)
            {
                if (slot < _inventory.items.Count)
                {
                    _slots[slot].AddItem(_inventory.items[slot]);
                    var slotCopy = slot;
                    _slots[slot].GetComponentInChildren<Button>().onClick.AddListener(() =>
                    {
                        UpdateDescriptionText(_slots[slotCopy].Item.description);
                    });
                }
                else
                    _slots[slot].ClearSlot();
            }
        }

        private void UpdateDescriptionText(string description)
        {
            itemDescription.text = description;
        }
    }
}
