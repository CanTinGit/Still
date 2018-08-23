using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupFallAudio : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        
        if(col.transform.name == "sm_book")
        {
            AkSoundEngine.PostEvent("cup_fall_trigger", gameObject);
        }
        if (col.transform.name == "sm_pokeFingerMachineHand")
        {
            AkSoundEngine.PostEvent("cup_squeak_trigger", gameObject);
        }
    }
}
