using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettingButon : MonoBehaviour {

    Transform button;               //Get the transform of the button
    public float setWeight;         //Setting weight to check if the button is pressed 
    Vector3 originalPosition;       //Save the original data of the button in order to change it back when realsing
    public Animator animator;       //Get the animator that is accessed to the button so that we can play animation when we need
    public bool isRunOnce;          //Set to check if the button just run once
    public bool isSpecificObject;   //When it's set, only the specific object can trigger the button or trapss
    public float noise;             //Noise value
    public string noise_detection;  //the name of the noise
    public GameObject SpecificObject; //Set the the specific object
    public string animationToReset;
    public GameObject Lever;

    // Use this for initialization
    void Start ()
    {
        button = gameObject.transform.parent;
        originalPosition = button.gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int type = 1;
        //float value;
        //AkSoundEngine.GetRTPCValue("noise_detection", gameObject, 0, out value, ref type);
        //noise = value;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the mass of object is more than setting weight, if it is, it can make trap run.
        if (other.GetComponent<Rigidbody>().mass >= setWeight)
        {
            // Button go down
            button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
            //AkSoundEngine.PostEvent("button_click", gameObject);
            Debug.Log(noise);

            //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
            if (isRunOnce == true)
            {
                // do nothing
                //animator.SetTrigger("TrapRun");
            }
            else
            {
                Debug.Log("Reset LEVER!");
                Lever.GetComponent<ActiveInScene>().setActive(false);
                animator.SetBool(animationToReset, false);
            }

        }
    }

    //When the button is released
    void OnTriggerExit(Collider other)
    {
        button.position = originalPosition;
    }
}
