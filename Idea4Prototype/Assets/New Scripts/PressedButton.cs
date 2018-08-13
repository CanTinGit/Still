using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedButton : MonoBehaviour {

    Transform button;               //Get the transform of the button
    public float setWeight;         //Setting weight to check if the button is pressed
    Vector3 originalPosition;       //Save the original data of the button in order to change it back when realsing
    public Animator animator;       //Get the animator that is accessed to the button so that we can play animation when we need
    public bool isRunOnce;          //Set to check if the button just run once
    public bool isSpecificObject;   //When it's set, only the specific object can trigger the button or trapss
    public float noise;             //Noise value
    public string noise_detection;  //the name of the noise
    public string SpecificObjectTag; //Set the the specific object
    public string animatorVariable; //String of the animationVraiable boolean
    public bool runAnimOnPressed;
    public bool runAnimOnReleased;
    public string soundName;
    public float delaySound;
    public List<GameObject> top = new List<GameObject>();
    public bool blinkingLights;
    public GameObject blinkButton;
    public float lowEmissiveStrength,highEmissiveStrength;
    bool blinkHigh = true;
    float blinkEmissiveStrength=0;
    public float blinkRateIncease;


    // Use this for initialization, set the button and original position of button
    void Start ()
    {
        button = gameObject.transform.parent;
        originalPosition = button.gameObject.transform.position;
    }

   // Noise detection wiise function, set the noise value every frame
    void LateUpdate()
    {
        if(blinkingLights)
        {
            blinkButton.GetComponent<MeshRenderer>().material.SetFloat("_Emissive_Strength", blinkEmissiveStrength);
            if (blinkHigh)
            {
                Debug.Log("increase blink");
                blinkEmissiveStrength += blinkRateIncease;              
            }
            else
            {
                Debug.Log("decrease blink");
                blinkEmissiveStrength -= blinkRateIncease;
            }
            if(blinkEmissiveStrength >= highEmissiveStrength || blinkEmissiveStrength <= lowEmissiveStrength)
            {
                Debug.Log("switched before " + blinkingLights);
                blinkHigh = !blinkHigh;
                Debug.Log("switched after " + blinkingLights);
            }
            Debug.Log("the blinkEmissiveStrength " + blinkEmissiveStrength);
        }
    //    //int type = 1;
    //    //float value;
    //    //AkSoundEngine.GetRTPCValue("noise_detection", gameObject, 0, out value, ref type);
    //    //noise = value;
    }

    //Check if something enter the trigger
    void OnTriggerEnter(Collider other)
    {
        //If the button is made for specific object, only specific object can trigger the button
        if (isSpecificObject)
        {
            //Check if the object trigger the button is the specific object
            if (other.gameObject.tag == SpecificObjectTag)
            {
                top.Add(other.gameObject);
                //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
                if (isRunOnce == true)
                {
                    animator.SetTrigger(animatorVariable);
                }
                else
                {
                    animator.SetBool(animatorVariable, runAnimOnPressed);
                }
            }
            return;
        }
        if((other.gameObject.GetComponent<Rigidbody>() != null) && this.GetComponent<PressedButton>().enabled==true && other.gameObject.name != "Hand")
        {
            // Check if the mass of object is more than setting weight, if it is, it can make trap run.
            if ((other.gameObject.GetComponent<Rigidbody>().mass >= setWeight))
            {
                top.Add(other.gameObject);
                // Button go down
                button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
                //AkSoundEngine.PostEvent("button_click", gameObject);
                //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
                if (isRunOnce == true)
                {

                    animator.SetTrigger(animatorVariable);
                }
                else
                {
                    if (animator != null)
                    {
                        animator.SetBool(animatorVariable, runAnimOnPressed);
                    }
                }

                // Button go down
                button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
                AkSoundEngine.PostEvent("button_click", gameObject);
                //Debug.Log(noise);

                //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
                if (isRunOnce == true)
                {
                    animator.SetTrigger(animatorVariable);
                }
                else
                {
                    if (animator != null)
                    {
                        animator.SetBool(animatorVariable, runAnimOnPressed);
                    }
                }

            }
        }
   }

    //When the button is realsed
    void OnTriggerExit(Collider other)
    {
        if(this.GetComponent<PressedButton>().enabled == true)
        {
            top.Remove(other.gameObject);
            if (top.Count > 0)
            {
                return;
            }
            button.position = originalPosition;
            if (isRunOnce == false)
            {
                //if(animator.GetBool(animatorVariable)==false)
                {
                    if (soundName != "")
                    {
                        Invoke("Delay", delaySound);
                    }
                    if (animator != null)
                    {
                        animator.SetBool(animatorVariable, runAnimOnReleased);
                    }
                }
            }
        }
    }
    void Delay()
    {
        AkSoundEngine.PostEvent(soundName, gameObject);
    }
}
