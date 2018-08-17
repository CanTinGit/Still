using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAudio : MonoBehaviour {

    public void PlayElectricity()
    {
        AkSoundEngine.PostEvent("electricity", gameObject);
    }
    public void PlayPull()
    {
        AkSoundEngine.PostEvent("pull_lever", gameObject);
    }
}
