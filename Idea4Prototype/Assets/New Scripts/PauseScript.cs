using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PauseScript : MonoBehaviour
{
    bool active,flipped;
    public GameObject PausePanel;                   // Pause panel to be displayed/hidden
    GameObject eventSystem;                      // Reference to the evennt system to allow for controller focus
	// Use this for initialization
	void Start ()
    {
        active = false;
        flipped = false;
        PausePanelOff();
        eventSystem = GameObject.Find("EventSystem");      // Set the eventSystem gameobject to the scenes EventSystem
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Start" + this.transform.name.Remove(0, 6)))                    // If the start button has been pressed
        {
            if (MenuScript.Instance.pausePlayerNum == 0)
            {
                Pause();
            }
            else
            {
                if (int.Parse(this.transform.name.Remove(0, 6)) == MenuScript.Instance.pausePlayerNum)
                {
                    UnPause();
                }
            }
            //if(PausePanel.activeSelf==false)
            //{
            //    PausePanelOn();
            //    flipped = true;
            //}
            //else if(PausePanel.activeSelf==true)
            //{
            //    PausePanelOff();
            //}
            //FlipPausePanel();                               // Turn on or off the pause screen panel
            if (PausePanel.gameObject.activeSelf == true)    // If the pause screen panel is visible, i.e. the player has paused the game
            {
                eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ResetButton"));  // Focus the event system on the pause screen buttons so the user can navigate it via controller
            }

        }
		
        //else if(Input.GetButtonDown("Start" + this.transform.name.Remove(0, 6)) && flipped == true)
        //{
        //    if (PausePanel.activeSelf == true)
        //    {
        //        PausePanelOff();
        //        flipped = false;
        //    }
        //}

    }
    void FlipPausePanel()
    {
        PausePanel.gameObject.SetActive(!PausePanel.activeSelf);        // Turn on or off the pause screen panel
    }
    void PausePanelOn()
    {
        PausePanel.gameObject.SetActive(true);        // Turn on or off the pause screen panel
    }
    void PausePanelOff()
    {
        PausePanel.gameObject.SetActive(false);        // Turn on or off the pause screen panel
    }
    public bool GetActive()
    {
        return active;
    }
    public bool GetPanelActive()
    {
        return PausePanel.activeSelf;
    }
    public void Pause()
    {
        FlipPausePanel();
        MenuScript.Instance.SetPlayerPaused(true);
        MenuScript.Instance.pausePlayerNum = int.Parse(this.transform.name.Remove(0, 6));
    }
    public void UnPause()
    {
        FlipPausePanel();
        MenuScript.Instance.SetPlayerPaused(false);
        MenuScript.Instance.pausePlayerNum = 0;
    }
}
