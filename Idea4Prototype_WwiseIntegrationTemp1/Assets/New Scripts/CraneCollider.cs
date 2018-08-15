using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneCollider : MonoBehaviour
{
    public Animator craneAnimator;
    public bool Release;

    void Start()
    {
        Release = false;
    }

	void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.name);
        if(other.gameObject.name.Contains("pCylinder") == true)
        {

            //print(other.name);
            //craneAnimator.SetBool("isButtonReleased", true);
            Release = true;
            Debug.Log(Release);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("pCylinder") == true)
        {
            //print(other.name);
            //craneAnimator.SetBool("isButtonReleased", true);
            Release = false;
        }
    }
}
