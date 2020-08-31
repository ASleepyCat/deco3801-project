using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            InvokeEvent();
    }

    // This handles NPC/pbject specific actions i.e. dialogue.
    // For NPCs, this could initiate the dialogue system.
    // For objects, this could initiate a loading sequence (doors, entrances).
    protected abstract void InvokeEvent();
}
