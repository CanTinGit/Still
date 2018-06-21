using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSticker : MonoBehaviour {

    public GameObject objCanPick;
    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(objCanPick!=null)
            {
 
                    if (objCanPick.GetComponent<ObjectsCanBeDragged>().picking == true)
                    {
                        objCanPick.GetComponent<ObjectsCanBeDragged>().picking = false;
                        return;
                    }
                    else if (objCanPick.GetComponent<ObjectsCanBeDragged>().picking == false)
                    {
                        objCanPick.GetComponent<ObjectsCanBeDragged>().picking = true;
                    }
                
            }
           
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            objCanPick = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            objCanPick = null;
        }
    }
}
