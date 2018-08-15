using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAnimSetter : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("Push", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("Push", false);
        }
    }
}
