using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerCode : MonoBehaviour {

    Animator cameraAnimator;
    public string animatorTrigger;
    public string soundName;
    public string congratulateSoundName;
    public GameObject infoSubtitle;
    public GameObject RetreatBlocker;       // Bounding volume game object which stops the player from going back
    GameObject blockingVolume;
    int NumPlayers = 0;
    public bool isFirst;
    // Use this for initialization
    void Start ()
    {
        cameraAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        if (this.gameObject.transform.childCount != 0)
        {
            blockingVolume = this.gameObject.transform.GetChild(0).gameObject;
        }
        if (isFirst)
        {
            Invoke("showSubtitle", 0f);   // Show the subtitile after a delay to match the camera animation
        }
    }


    // If the Players reach the goal area, play the camera moving animation

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Minus the number of players in goal area.
            NumPlayers--;
            if (infoSubtitle != null)
            {
                infoSubtitle.SetActive(false);                  // When the players leave, get rid of the subtitle
            }
            if(NumPlayers == 0)
            {
                this.gameObject.SetActive(false);               // Ensures double audio cannot occur by disabling trigger zone
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (isFirst)
        {
            return;
        }
        if (col.gameObject.tag == "Player")
        {
            // Add to the number of players in trigger area
            NumPlayers++;
            if (NumPlayers == MenuScript.Instance.GetNumberofPlayers())      //MenuScript.Instance.GetNumberofPlayers()   // If the number of players in the area equals the total number of players in the scene
            {
                RetreatBlocker.SetActive(true);     // Set the gameobject to active so the players cannot move back

                if (animatorTrigger != "")
                {
                    cameraAnimator.SetTrigger(animatorTrigger);     // If the animator trigger string isn't null set it so the animation plays
                }
                if(congratulateSoundName != "")
                {
                    CongratulatePlayer();
                }
                else
                {                  
                    Invoke("showSubtitle", 1.5f);   // Show the subtitile after a delay to match the camera animation
                }
                //if (this.gameObject.transform.childCount != 0)
                //{
                //    blockingVolume.SetActive(false);
                //}
            }
        }
    }
    void CongratulatePlayer()
    {
        AkSoundEngine.PostEvent(congratulateSoundName, gameObject);     // Post sound event defined by the string soundName
        Invoke("showSubtitle", 1.5f);   // Show the subtitile after a delay to match the camera animation
    }
    void showSubtitle()
    {
        if(infoSubtitle != null)
        {
            infoSubtitle.SetActive(true);
        }
        // Insert audio code here
        //AkSoundEngine.PostEvent(soundName, gameObject);
        AkSoundEngine.PostEvent(soundName, gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);    // Post sound event defined by the string soundName
    }
    //incase you want to play audio with no delay or subtitles with it
    void PlayNormalAudio()
    {
        //AkSoundEngine.PostEvent(soundName, gameObject);
        AkSoundEngine.PostEvent(soundName, gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);     // Post sound event defined by the string soundName
    }

    void MyCallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)

    {

        if (in_type == AkCallbackType.AK_EndOfEvent)

        {

            AkEventCallbackInfo info = (AkEventCallbackInfo)in_info;
            //Then do stuff.
            if (blockingVolume != null)
            {
                blockingVolume.SetActive(false);
            }

        }

    }
}
