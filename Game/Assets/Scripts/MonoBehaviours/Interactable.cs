using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class Interactable : MonoBehaviour
    {
        public Item item;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && Input.GetButton("Interact"))
                InvokeEvent();
        }

        /// <summary>
        /// Initiates dialogue for an NPC or object.
        /// </summary>
        private void InvokeEvent()
        {
            Debug.Log("interact");
            // Return if player is already busy
            if (!PlayerManager.instance.PlayerState.SetPlayerState(PlayerState.States.InDialogue)) return;
            Inventory.instance.AddItem(item); // TODO: Change this to start dialogue
            PlayerManager.instance.PlayerState.SetPlayerState(PlayerState.States.Free);
        }
    }
}
