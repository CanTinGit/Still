using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public bool showInfo;
    public string soundName;
    public GameObject infoSubtitle;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.tag == "MainCamera" && showInfo == true)
        {
           // AkSoundEngine.PostEvent(soundName, gameObject);
            infoSubtitle.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        infoSubtitle.SetActive(false);
    }
}
