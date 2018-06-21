using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour {

    public GameObject Player1, Player2, Player3, Player4;
	// Use this for initialization
	void Start ()
    {
        // Sets the  number of visible/ active players in the scene based on the numPlayer value passed from the main menu
		if(MenuScript.Instance.GetNumberofPlayers() == 4)
        {
            Player1.gameObject.SetActive(true);
            Player2.gameObject.SetActive(true);
            Player3.gameObject.SetActive(true);
            Player4.gameObject.SetActive(true);
        }
        else if(MenuScript.Instance.GetNumberofPlayers() == 3)
        {
            Player1.gameObject.SetActive(true);
            Player2.gameObject.SetActive(true);
            Player3.gameObject.SetActive(true);
        }
        else if(MenuScript.Instance.GetNumberofPlayers() == 2)
        {
            Player1.gameObject.SetActive(true);
            Player2.gameObject.SetActive(true);
        }
        else
        {
            Player1.gameObject.SetActive(true);
        }
	}
}
