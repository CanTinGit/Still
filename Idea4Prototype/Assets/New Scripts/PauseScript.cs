using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PauseScript : MonoBehaviour
{
    bool active;
    public GameObject PausePanel;                   // Pause panel to be displayed/hidden
    GameObject eventSystem;                         // Reference to the evennt system to allow for controller focus
	// Use this for initialization
	void Start ()
    {
        active = false;
        FlipPausePanel();
        eventSystem = GameObject.Find("EventSystem");      // Set the eventSystem gameobject to the scenes EventSystem
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Start"))                    // If the start button has been pressed
        {
            active = !active;
            FlipPausePanel();                               // Turn on or off the pause screen panel
            if(PausePanel.gameObject.activeSelf == true)    // If the pause screen panel is visible, i.e. the player has paused the game
            {
                eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ResetButton"));  // Focus the event system on the pause screen buttons so the user can navigate it via controller
            }
        }
        if (active == true)
        {
            //Time.timeScale = 0.0f;
        }
        else
        {
           // Time.timeScale = 1.0f;
        }
    }

    void FlipPausePanel()
    {
        PausePanel.gameObject.SetActive(!PausePanel.activeSelf);        // Turn on or off the pause screen panel
    }
    public bool GetActive()
    {
        return active;
    }
}
