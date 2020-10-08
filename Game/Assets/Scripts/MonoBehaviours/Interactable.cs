using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class Interactable : MonoBehaviour
    {
        public Item item;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

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
            if (!_gameManager.PlayerState.SetPlayerState(PlayerState.States.InDialogue)) return;
            _gameManager.inventory.AddItem(item); // TODO: Change this to start dialogue
            _gameManager.PlayerState.SetPlayerState(PlayerState.States.Free);
        }
    }
}
