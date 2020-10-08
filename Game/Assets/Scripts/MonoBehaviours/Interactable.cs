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
            if (!PlayerManager.Instance.PlayerState.SetPlayerState(PlayerState.States.InDialogue)) return;
            Inventory.Instance.AddItem(item); // TODO: Change this to start dialogue
            PlayerManager.Instance.PlayerState.SetPlayerState(PlayerState.States.Free);
        }
    }
}
