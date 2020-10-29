using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class Interactable : MonoBehaviour
    {
        //Stored current VA when inside a trigger
        public BoxCollider2D trigger;
        public Item item;
        public VIDE_Assign inTrigger;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

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
   
            if (!_gameManager.PlayerState.SetPlayerState(PlayerState.States.InDialogue)) return;
            UIManager2.Instance.Interact(inTrigger);
            if (item != null)
            {
                GameManager.Instance.inventory.AddItem(item);
                trigger.isTrigger = false;
            }
            //_gameManager.PlayerState.SetPlayerState(PlayerState.States.Free);
        }
    }
}
