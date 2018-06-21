using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfulButton : MonoBehaviour {

    Transform button;
    public float setWeight;
    Vector3 originalPosition;
    public Animator animator;
    public bool isRunOnce;
    // Use this for initialization
    void Start()
    {
        button = gameObject.transform.parent;
        originalPosition = button.gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the mass of object is more than setting weight, if it is, it can make trap run.
        if (other.GetComponent<Rigidbody>().mass >= setWeight)
        {
            // Check if the color of object is same as button, if it is, it can make trap run.
            if (other.gameObject.GetComponent<Renderer>().material.color == transform.parent.gameObject.GetComponent<Renderer>().material.color)
            {
                // Button go down
                button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z); 
                  
                //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
                if (isRunOnce == true)
                {
                    animator.SetTrigger("TrapRun");
                }
                else
                {
                    animator.SetBool("TrapRun", true);
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When there is no object on the button, button go up and make trap return to original state
        button.position = originalPosition;
        if (isRunOnce == false)
        {
            animator.SetBool("TrapRun", false);
        }
    }
}
