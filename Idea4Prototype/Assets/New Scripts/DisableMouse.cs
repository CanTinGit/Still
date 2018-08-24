using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMouse : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
}
