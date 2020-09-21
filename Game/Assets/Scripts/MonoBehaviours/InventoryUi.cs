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
        
        private void Start()
        {
            _inventory = Inventory.instance;
            _inventory.onItemAddedCallback = UpdateUi;
            _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
            _playerManager = PlayerManager.instance;
        }

        private void Update()
        {
            if (!Input.GetButtonDown("Inventory")) return;
            var state = !inventoryUi.activeSelf
                ? PlayerState.States.InInventory
                : PlayerState.States.Free;
            if (_playerManager.PlayerState.SetPlayerState(state))
                inventoryUi.SetActive(!inventoryUi.activeSelf);
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
