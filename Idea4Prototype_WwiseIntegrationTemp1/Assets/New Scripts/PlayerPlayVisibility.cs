using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayVisibility : MonoBehaviour {

    //GameObject[] controllerSelectors;
    bool Play1, Play2, Play3, Play4;
    public GameObject playButton;
	// Use this for initialization
	void Awake ()
    {
        //for(int x = 0; x == this.transform.childCount; x++)
        //{
        //    controllerSelectors[x] = this.transform.GetChild(x).gameObject;

        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int x = 0; x < this.gameObject.transform.childCount; x++)
        {
            //if (this.gameObject.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().isSelected == this.gameObject.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().isInGame == this.gameObject.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().PlayerStart)
            //{

            //}

            if(this.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().isSelected == this.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().isInGame/* || this.transform.GetChild(x).gameObject.GetComponent<ControllerSelect>().isSelected == false*/)
            {
                
                if(x == 0)
                {
                    Play1 = true;
                }
                else if(x == 1)
                {
                    Play2 = true;
                }
                else if(x == 2)
                {
                    Play3 = true;
                }
                else if(x == 3)
                {
                    Play4 = true;
                }
            }
            else
            {                       //Player is still selecting their character so dont show start button
                if (x == 0)
                {
                    Play1 = false;
                }
                else if (x == 1)
                {
                    Play2 = false;
                }
                else if (x == 2)
                {
                    Play3 = false;
                }
                else if (x == 3)
                {
                    Play4 = false;
                }
            }

        }

        if(MenuScript.Instance.GetNumberofPlayers() > 0)            // If someone's readied into the game
        {
            if (Play1 == true && Play2 == true && Play3 == true && Play4 == true)
            {
                // Display Next screen button
                playButton.SetActive(true);
                //MenuScript.Instance.ContinuePressed();

            }
            else
            {
                playButton.SetActive(false);
            }
        }
        else if(MenuScript.Instance.GetNumberofPlayers() == 0)
        {
            playButton.SetActive(false);
        }
    }
}
