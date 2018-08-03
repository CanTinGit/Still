using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    
	// Use this for initialization
	void Awake ()
    {
        AkSoundEngine.StopAll();
		if(GameObject.Find("GameManager")==null)
        {
            GameObject gm = new GameObject("GameManager");
            gm.AddComponent<MenuScript>();
            gm.tag = "GameManager";
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<MenuScript>().IntialiseAndSetScene();
        }
        Destroy(this.gameObject);
    }

}
