using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightTrigger : MonoBehaviour
{
    GameObject crane;

    void Start()
    {
        crane = GameObject.Find("Crane_base");
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "weight")
        {
            crane.GetComponent<Animator>().SetBool("isWeightReleased", false);
        }
    }
}
