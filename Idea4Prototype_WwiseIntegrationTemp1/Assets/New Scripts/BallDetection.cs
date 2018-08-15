using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour {

    public Animator pulleyweightAnimator;
    public Animator pulleyrecepticleAnimator;

    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Sphere") == true)
        {
            
            pulleyweightAnimator.SetBool("isWeighted", true);
            pulleyrecepticleAnimator.SetBool("isDecending", true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Sphere") == true)
        {
            other.transform.position = gameObject.transform.position;
        }
    }
}
