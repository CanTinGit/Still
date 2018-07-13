using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerCode : MonoBehaviour {

    Animator cameraAnimator;
    public string animatorTrigger;
    int NumPlayers = 0;
    // Use this for initialization
    void Start ()
    {
        cameraAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // If the Players reach the goal area, play the camera moving animation

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Minus the number of players in goal area.
            NumPlayers--;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Add to the number of players in trigger area
            NumPlayers++;
            if (NumPlayers == MenuScript.Instance.GetNumberofPlayers())
            {
                if (animatorTrigger != "")
                {
                    cameraAnimator.SetTrigger(animatorTrigger);
                }
                // Insert audio code here
            }
        }
    }
}
