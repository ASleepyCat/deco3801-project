using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class InventoryScript : MonoBehaviour
    {
        public const int NumItemSlots = 10;
        public Image[] itemImages = new Image[NumItemSlots];
        public Item[] items = new Item[NumItemSlots];
        public int ItemIndex { get; private set; }

        /// <summary>
        /// Adds an item to the inventory. Will not add a new item if the inventory is already full.
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <returns>True if successful, false if the inventory is full and can longer add more items.</returns>
        public bool AddItem(Item itemToAdd)
        {
            if (ItemIndex >= NumItemSlots) return false;
            items[ItemIndex] = itemToAdd;
            itemImages[ItemIndex].sprite = itemToAdd.sprite;
            itemImages[ItemIndex].enabled = true;
            ++ItemIndex;
            return true;
        }
    }
}
