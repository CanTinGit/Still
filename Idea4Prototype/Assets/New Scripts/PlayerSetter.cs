using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour {

    public GameObject Player1, Player2, Player3, Player4;
    string player1Nationality, player2Nationality, player3Nationality, player4Nationality;
    // Use this for initialization
    void Start ()
    {
        // AkSoundEngine.PostEvent("stop_level_music", gameObject);
        AkSoundEngine.StopAll();
        AkSoundEngine.SetSwitch("Music_Transition", "Section1", gameObject);
        // Sets the  number of visible/ active players in the scene based on the numPlayer value passed from the main menu
        if (MenuScript.Instance.p1InGame == true)
        {
            Player1.gameObject.SetActive(true);
        }
        if(MenuScript.Instance.p1InGame == false)
        {
            Player1.gameObject.SetActive(false);
        }
        if(MenuScript.Instance.p2InGame == true)
        {
            Player2.gameObject.SetActive(true);
        }
        if (MenuScript.Instance.p2InGame == false)
        {
            Player2.gameObject.SetActive(false);
        }
        if (MenuScript.Instance.p3InGame == true)
        {
            Player3.gameObject.SetActive(true);
        }
        if (MenuScript.Instance.p3InGame == false)
        {
            Player3.gameObject.SetActive(false);
        }
        if (MenuScript.Instance.p4InGame == true)
        {
            Player4.gameObject.SetActive(true);
        }
        if (MenuScript.Instance.p4InGame == false)
        {
            Player4.gameObject.SetActive(false);
        }
        AkSoundEngine.PostEvent("play_level_music", gameObject);
    }

    public void ChangeTransition(string section)
    {
        AkSoundEngine.PostEvent("stop_level_music", gameObject);
        AkSoundEngine.SetSwitch("Music_Transition", section, gameObject);
    }
}
