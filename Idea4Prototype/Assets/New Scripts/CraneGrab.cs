using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneGrab : MonoBehaviour {

    public Animator cranegrabAnim;

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
            if (cranegrabAnim.GetBool("isCraneRelease") == false)
            {
                other.transform.position = gameObject.transform.position;
            }
        }
    }
}
