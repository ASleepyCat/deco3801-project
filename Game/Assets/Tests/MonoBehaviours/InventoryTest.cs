using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;

namespace Tests.MonoBehaviours
{
    [TestFixture]
    public class InventoryTest
    {
        [Test]
        public void AddItemTest()
        {
            var inventory = ScriptableObject.CreateInstance<Inventory>();
            var item = ScriptableObject.CreateInstance<Item>();
            var addedItem = true;

            inventory.AddItem(item);
            Assert.AreEqual(inventory.GetInventoryCount(), 1);

            // Check if item adding limit works
            for (var i = 0; i < inventory.size + 1; ++i)
                addedItem = inventory.AddItem(item);
            Assert.True(!addedItem);
            Assert.AreEqual(inventory.GetInventoryCount(), inventory.size);
        }

        [Test]
        public void GetInventoryCountTest()
        {
            var inventory = ScriptableObject.CreateInstance<Inventory>();
            Assert.AreEqual(inventory.GetInventoryCount(), 0);
        }
    }
}
