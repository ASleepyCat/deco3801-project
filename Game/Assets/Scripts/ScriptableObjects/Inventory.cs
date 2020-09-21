using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class Inventory : ScriptableObject
    {
        public static Inventory instance;
        public int size = 14;
        public List<Item> items = new List<Item>();
        public delegate void OnItemAdded(); // Used to update the inventory UI
        public OnItemAdded onItemAddedCallback;
        
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of " + GetType().Name + " found!");
                return;
            }
            instance = this;
        }

        /// <summary>
        /// Adds an item to the inventory. Will not add a new item if the inventory is already full.
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <returns>True if successful, false if the inventory is full and can longer add more items.</returns>
        public bool AddItem(Item itemToAdd)
        {
            Debug.Log("adding " + itemToAdd.name + " to inventory");
            if (items.Count >= size) return false;
            items.Add(itemToAdd);
            onItemAddedCallback?.Invoke();
            return true;
        }

        public int GetInventoryCount()
        {
            return items.Count;
        }
    }
}
