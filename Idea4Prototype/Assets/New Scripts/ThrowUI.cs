using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUI : MonoBehaviour {

    public GameObject ThrowUIMessage;               // Message to be displayed

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")                   // If a player eneters the trigger zone
        {
            if (ThrowUIMessage != null)             // If the Message game object is not null i.e. it exists
            {
                ThrowUIMessage.SetActive(true);     // Show it
            }
        }
    }

    void OnTriggerExit(Collider other)              
    {
        if(other.tag == "Player")                   // If a player leaves the trigger zone
        {
            DestroyObject(ThrowUIMessage, 5.0f);   // Destroy the UI message after 5 seconds
        }
    }
}
