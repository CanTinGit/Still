using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityAttractor : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            other.gameObject.GetComponent<gravityBody>().canBeAttracted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            other.gameObject.GetComponent<gravityBody>().canBeAttracted = false;
        }
    }
}