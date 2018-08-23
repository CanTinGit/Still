using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowningAnimPlayer : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("isDrowning", true);
            other.gameObject.GetComponent<MovementUpdated>().enabled = false;
            other.gameObject.transform.Find("Hand").GetComponent<PickUpUpdated>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("isDrowning", false);
            other.gameObject.GetComponent<MovementUpdated>().enabled = true;
            other.gameObject.transform.Find("Hand").GetComponent<PickUpUpdated>().enabled = true;
        }
    }
}
