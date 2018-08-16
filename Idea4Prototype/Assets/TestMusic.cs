using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //AkSoundEngine.SetSwitch("Music_Transition", "Section1", gameObject);
        AkSoundEngine.PostEvent("play_level_music", gameObject);
    }
	

    public void SwicthToSecond()
    {
        AkSoundEngine.SetSwitch("Music_Transition", "Section2", gameObject);
    }


    public void SwicthToThree()
    {
        AkSoundEngine.SetSwitch("Music_Transition", "Section3", gameObject);
    }
}
