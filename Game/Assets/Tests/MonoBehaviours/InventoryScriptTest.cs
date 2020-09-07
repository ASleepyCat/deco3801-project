using MonoBehaviours;
using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;

namespace Tests.MonoBehaviours
{
    public class InventoryScriptTest
    {
        [Test]
        public void TestAddItem()
        {
            // Yes, Unity complains about this. No, this is fine.
            var inventory = new InventoryScript();
            var item = ScriptableObject.CreateInstance<Item>();
            var addedItem = true; // Need to assign else Unity throws an error
            
            Assert.AreEqual(inventory.ItemIndex, 0);
            
            inventory.AddItem(item);
            Assert.AreEqual(inventory.ItemIndex, 1);

            // Check if item adding limit works
            for (var i = 0; i < InventoryScript.NumItemSlots + 1; ++i)
                addedItem = inventory.AddItem(item);
            Assert.True(!addedItem);
        }
    }
}
