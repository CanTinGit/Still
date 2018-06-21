using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTester : MonoBehaviour {

    private int Xbox_One_Controller = 0;
    int SingleController = 33;
	// Update is called once per frame
	void Update ()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == SingleController)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                Xbox_One_Controller = 1;
            }
            if (names[x].Length == SingleController * 2)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                Xbox_One_Controller = 2;
            }
        }
    }
}
