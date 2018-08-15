using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    
	// Use this for initialization
	void Start ()
    {
        Debug.Log("Test");
        AkSoundEngine.StopAll();
        AkSoundEngine.SetSwitch("intro", "splash", gameObject);
        AkSoundEngine.PostEvent("play_music", gameObject);
        //if (GameObject.Find("GameManager") == null)
        //{
        //    GameObject gm = new GameObject("GameManager");
        //    gm.AddComponent<MenuScript>();
        //    gm.tag = "GameManager";
        //}
        //else
        //{
        //    GameObject.Find("GameManager").GetComponent<MenuScript>().IntialiseAndSetScene();
        //}
        //Destroy(this.gameObject);
    }


    public void Play(string transition)
    {
        AkSoundEngine.SetSwitch("intro",transition, gameObject);
    }
}
