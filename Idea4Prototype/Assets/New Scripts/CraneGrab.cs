using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneGrab : MonoBehaviour {

    public Animator cranegrabAnim;
    GameObject ReleaseTrigger;

    void Start()
    {
        ReleaseTrigger = GameObject.Find("ReleaseTrigger");
    }
	void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Goal") == true)
        {
            other.transform.position = gameObject.transform.position;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Goal") == true)
        {
            if (ReleaseTrigger.GetComponent<CraneCollider>().Release == false)
            {
                other.transform.position = gameObject.transform.position;
            }
        }
    }
}
