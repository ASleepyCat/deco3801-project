using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    // Wrapper class for Inventory
    public class InventoryBehaviour : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = new Inventory();
        }

        public void AddItem(Item itemToAdd)
        {
            _inventory.AddItem(itemToAdd);
        }
    }

    public class Inventory
    {
        public const int NumItemSlots = 10;

        public Image[] itemImages = new Image[NumItemSlots];
        public Item[] items = new Item[NumItemSlots];

        public int ItemIndex { get; private set; }

        public void AddItem(Item itemToAdd)
        {
            if (ItemIndex >= NumItemSlots) return;
            items[ItemIndex] = itemToAdd;
            items[ItemIndex].sprite = itemToAdd.sprite;
            items[ItemIndex].description = itemToAdd.description;
            ++ItemIndex;
        }
    }
}
