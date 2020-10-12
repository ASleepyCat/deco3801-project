using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;

namespace Tests.ScriptableObjects
{
    public class PlayerHealthTest
    {
        [Test]
        public void DecrementHealthTest()
        {
            var playerHealth = ScriptableObject.CreateInstance<PlayerHealth>();
            playerHealth.DecrementHealth();
            Assert.AreEqual(2, playerHealth.health);
            
            for (var i = 0; i < 3; ++i)
                playerHealth.DecrementHealth();
            Assert.AreEqual(0, playerHealth.health);
        }

        [Test]
        public void IsGameOverTest()
        {
            var playerHealth = ScriptableObject.CreateInstance<PlayerHealth>();
            Assert.False(playerHealth.IsGameOver());
            
            for (var i = 0; i < 3; ++i)
                playerHealth.DecrementHealth();
            Assert.True(playerHealth.IsGameOver());
        }
    }
}
