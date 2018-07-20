using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour {

    public GameObject Player1, Player2, Player3, Player4;
    string player1Nationality, player2Nationality, player3Nationality, player4Nationality;
    // Use this for initialization
    void Start ()
    {
        // Sets the  number of visible/ active players in the scene based on the numPlayer value passed from the main menu
		if(MenuScript.Instance.p1InGame == true)
        {
            Player1.gameObject.SetActive(true);
        }
        if(MenuScript.Instance.p2InGame == true)
        {
            Player2.gameObject.SetActive(true);
        }
        if(MenuScript.Instance.p3InGame == true)
        {
            Player3.gameObject.SetActive(true);
        }
        if (MenuScript.Instance.p4InGame == true)
        {
            Player4.gameObject.SetActive(true);
        }

	}
}
