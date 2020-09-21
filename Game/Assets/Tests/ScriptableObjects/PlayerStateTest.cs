using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;

namespace Tests.ScriptableObjects
{
    public class PlayerStateTest
    {
        [Test]
        public void SetPlayerStateTest()
        {
            var state = ScriptableObject.CreateInstance<PlayerState>();
            Assert.AreEqual(PlayerState.States.Free, state.State);

            // Successfully set state since we're in Free
            var status = state.SetPlayerState(PlayerState.States.InDialogue);
            Assert.True(status);
            
            // Fails since we're busy in InDialogue
            status = state.SetPlayerState(PlayerState.States.InDialogue);
            Assert.False(status);
            
            // Fails since we're busy in InDialogue
            status = state.SetPlayerState(PlayerState.States.InInventory);
            Assert.False(status);
            
            // Successfully set back to Free
            status = state.SetPlayerState(PlayerState.States.Free);
            Assert.True(status);
        }
    }
}
