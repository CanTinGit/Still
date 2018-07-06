using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJumpSetter : MonoBehaviour {


    void OnTriggerEnter(Collider other)         // If the trigger collides with the ground, that means the above segment, i.e. the current top of the cube should be jumpable
    {
        if (other.gameObject.transform.parent != null)
        {
            if (other.gameObject.tag == "Ground" && other.gameObject.transform.parent.gameObject != this.gameObject.transform.parent.gameObject)        // If it collides with the ground
            {
                this.gameObject.tag = "Ground";         // Set the tag to ground so it is jumpable
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
       // if (other.gameObject.tag == "Ground" /*&& other.gameObject.transform.parent.gameObject != this.gameObject.transform.parent.gameObject*/)       // If it no longer collides with the ground
       // {
       if(other.gameObject.tag != "Player" && other.gameObject.tag != "Hand")
        {
            this.gameObject.tag = "Untagged";       // Set the tag to untagged so it is not jumpable
        }
       // }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent != null)
        {
            if (other.gameObject.tag == "Ground" && other.gameObject.transform.parent.gameObject != this.gameObject.transform.parent.gameObject)        // If it collides with the ground
            {
                this.gameObject.tag = "Ground";         // Set the tag to ground so it is jumpable
            }
        }
    }
}
