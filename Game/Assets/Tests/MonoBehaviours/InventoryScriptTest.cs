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
            var inventory = new Inventory();
            var item = ScriptableObject.CreateInstance<Item>();
            
            Assert.AreEqual(inventory.ItemIndex, 0);
            
            inventory.AddItem(item);
            Assert.AreEqual(inventory.ItemIndex, 1);

            // Check if item adding limit works
            for (var i = 0; i < Inventory.NumItemSlots + 1; ++i)
                inventory.AddItem(item);
            Assert.AreEqual(inventory.ItemIndex, Inventory.NumItemSlots);
        }
    }
}
