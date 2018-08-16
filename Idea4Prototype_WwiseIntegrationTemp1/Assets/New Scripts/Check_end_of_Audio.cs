using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_end_of_Audio : MonoBehaviour {

    object myCookieObject;
    public GameObject m_object;
    public string sound_name;

    // Use this for initialization
    void Start()
    {
        
    }

    public void playAudio()
    {
        AkSoundEngine.PostEvent(sound_name, gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);
    }


    void MyCallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)

    {

        if (in_type == AkCallbackType.AK_EndOfEvent)

        {

            AkEventCallbackInfo info = (AkEventCallbackInfo)in_info; //Then do stuff.
            m_object.SetActive(false);

        }

    }
}
