using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Joystick1Button0") || Input.GetButtonDown("Joystick2Button0") || Input.GetButtonDown("Joystick3Button0") || Input.GetButtonDown("Joystick4Button0"))
        {
            if(GameObject.Find("MenuPanel") != null)                // If A is pressed on the start screen
            {
                MenuScript.Instance.PlayPressed();                  // Go to character select
            }

        }
        if(Input.GetButtonDown("Joystick1Button1") || Input.GetButtonDown("Joystick2Button1") || Input.GetButtonDown("Joystick3Button1") || Input.GetButtonDown("Joystick4Button1"))
        {
            if(GameObject.Find("MenuPanel") != null)                // If B is pressed on the start screen
            {
                MenuScript.Instance.QuitApplication();              // Quit the application
            }
            if(GameObject.Find("LevelSelectPanel") != null)         // If B is pressed on the level select screen
            {
                MenuScript.Instance.ReturnToCharacterSelect();          // Return to the start screen
            }
        }

    }
}
