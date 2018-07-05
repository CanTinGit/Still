using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour {

    void Start()
    {
        AkSoundEngine.SetRTPCValue("click_start", 100f, null, 500);
        AkSoundEngine.PostEvent("play_intro", gameObject);
    }

    // Use this for initialization
    void OnEnable () {
        AkSoundEngine.SetRTPCValue("click_start", 100f, null, 500);
        AkSoundEngine.PostEvent("play_intro", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
