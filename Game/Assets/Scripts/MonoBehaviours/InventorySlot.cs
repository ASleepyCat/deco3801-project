using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon;
        public Item Item { get; private set; }

        public void AddItem(Item newItem)
        {
            Item = newItem;
            icon.sprite = Item.sprite;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            Item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}
