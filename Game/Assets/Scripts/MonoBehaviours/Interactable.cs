using ScriptableObjects;
using UnityEngine;
using VIDE_Data;

namespace MonoBehaviours
{
    public class Interactable : MonoBehaviour
    {
        //Reference to our diagUI script for quick access
        public UIManager diagUI;
        public Item item;

        //Stored current VA when inside a trigger
        public VIDE_Assign inTrigger;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && Input.GetButton("Interact"))
            {
                /*if (other.GetComponent<VIDE_Assign>() != null)
                {
                    inTrigger = other.GetComponent<VIDE_Assign>();
                }*/
                InvokeEvent();
            }      
        }

        /// <summary>
        /// Initiates dialogue for an NPC or object.
        /// </summary>
        private void InvokeEvent()
        {
            Debug.Log("interact");
            // Return if player is already busy
            if (!PlayerManager.Instance.PlayerState.SetPlayerState(PlayerState.States.InDialogue)) return;
            //Inventory.Instance.AddItem(item); // TODO: Change this to start dialogue
            diagUI.Interact(inTrigger);
            PlayerManager.Instance.PlayerState.SetPlayerState(PlayerState.States.Free);
        }
    }
}
