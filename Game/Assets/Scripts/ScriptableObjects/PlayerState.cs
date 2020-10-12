using UnityEngine;

namespace ScriptableObjects
{
    public class PlayerState : ScriptableObject
    {
        public enum States
        {
            Free, InDialogue, InInventory
        }
        public States State { get; private set; }

        /// <summary>
        /// Sets the player's state. This might be an incomplete implementation if collision trigger checks are ran in parallel.
        /// </summary>
        /// <param name="newState"></param>
        /// <returns>
        /// </returns> Returns false if the player is already busy doing something (in dialogue/looking at inventory), true otherwise.
        public bool SetPlayerState(States newState)
        {
            // Return if the player is already doing something and we're not setting the player back to a free state
            if (State != States.Free && newState != States.Free) return false;
            State = newState;
            return true;
        }

        public void ResetState()
        {
            SetPlayerState(States.Free);
        }
    }
}
