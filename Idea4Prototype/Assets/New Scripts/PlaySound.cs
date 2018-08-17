using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public void Sound(string eventname)
    {
        AkSoundEngine.PostEvent(eventname, gameObject);
    }
}
