//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class JoystickAssigner : MonoBehaviour {

//    public bool DisplayConnected;

//	// Use this for initialization
//	void Update ()
//    {
//        InvokeRepeating("CheckControllersConnected", 0.0f, 2.0f);	
//	}
	
//    void CheckControllersConnected()
//    {
//        string[] controllers = Input.GetJoystickNames();
//        //Iterate over every element
//        for (int i = 0; i < controllers.Length; ++i)
//        {
//            //Check if the string is empty or not
//            if (!string.IsNullOrEmpty(controllers[i]))
//            {
//                // Debug.Log(controllers[i]) ;
//                //Not empty, controller temp[i] is connected
//                //Debug.Log("Controller " + i + " is connected using: " + controllers[i]);
//                if (i == (playerNum - 1))
//                {
//                    DisplayConnected = true;
//                    //this.GetComponent<Image>().sprite = selectedControlSprite;
//                }
//            }
//            else
//            {
//                //If it is empty, controller i is disconnected
//                //where i indicates the controller number
//                //Debug.Log("Controller: " + i + " is disconnected.");
//                if (i == (playerNum - 1))
//                {
//                    DisplayConnected = false;
//                    //this.GetComponent<Image>().sprite = deselectedControlSprite;
//                    //playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
//                    //Choice = 0;
//                    //playerSprite.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = flags[Choice].GetSprite();
//                    //if (isInGame == true)
//                    //{
//                    //    isInGame = false;
//                    //    MenuScript.Instance.SetNumberofPlayers(-1);
//                    //    MenuScript.Instance.SetPlayersInGame(playerNum, false);
//                    //}

//                    //isSelected = false;
//                    //this.GetComponentInChildren<Text>().enabled = false;

//                }

//            }
//        }
//    }

//    public bool GetConnected()
//    {
//        return DisplayConnected;
//    }
//}
