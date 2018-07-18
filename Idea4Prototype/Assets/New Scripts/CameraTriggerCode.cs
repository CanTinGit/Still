using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerCode : MonoBehaviour {

    Animator cameraAnimator;
    public string animatorTrigger;
    public string soundName;
    public string congratulateSoundName;
    public GameObject infoSubtitle;
    int NumPlayers = 0;
    // Use this for initialization
    void Start ()
    {
        cameraAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
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
        if (col.gameObject.tag == "Player")
        {
            // Add to the number of players in trigger area
            NumPlayers++;
            if (NumPlayers == MenuScript.Instance.GetNumberofPlayers())      //MenuScript.Instance.GetNumberofPlayers()   // If the number of players in the area equals the total number of players in the scene
            {
                if (animatorTrigger != "")
                {
                    cameraAnimator.SetTrigger(animatorTrigger);     // If the animator trigger string isn't null set it so the animation plays
                }
                if(congratulateSoundName!="")
                {
                    CongratulatePlayer();
                }
                else
                {                  
                    Invoke("showSubtitle", 1.5f);   // Show the subtitile after a delay to match the camera animation
                }
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
        AkSoundEngine.PostEvent(soundName, gameObject);     // Post sound event defined by the string soundName
    }
    //incase you want to play audio with no delay or subtitles with it
    void PlayNormalAudio()
    {
        AkSoundEngine.PostEvent(soundName, gameObject);     // Post sound event defined by the string soundName
    }
}
