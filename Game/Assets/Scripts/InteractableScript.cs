using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Interact with NPC/object
        }
    }
}
