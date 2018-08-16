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
    //controls the blinking lights
    public bool blinkingLights; //controls whether the lights will blink for the button or not
    public GameObject blinkButton; //the button gameobject
    public float lowEmissiveStrength, highEmissiveStrength; // the values ranges it will go between for emissive strength
    bool blinkHigh = true; //a boolean to indicate if it will go to the upper limit or the lower limit ranges
    float blinkEmissiveStrength = 0; //the value the emissive strength will be set to
    public float blinkRateIncrease; //the rate it will change in emissive strength


    // Use this for initialization, set the button and original position of button
    void Start ()
    {
        button = gameObject.transform.parent;
        originalPosition = button.gameObject.transform.position;
    }

    //late update because it is only color change so do it on last frame of update
    void LateUpdate()
    {
        //if the lights shoul blink then
        if (blinkingLights)
        {
            //set the emissive strength to the new value
            blinkButton.GetComponent<MeshRenderer>().material.SetFloat("_Emissive_Strength", blinkEmissiveStrength);
            //based on if we are going to the upper or lower limit add on the blinkRateIncrease
            if (blinkHigh)
            {
                blinkEmissiveStrength += blinkRateIncrease;
            }
            else
            {
                blinkEmissiveStrength -= blinkRateIncrease;
            }
            //when we hit the upper limit or lower limit then change the boolean so we go to the other limit
            if (blinkEmissiveStrength >= highEmissiveStrength || blinkEmissiveStrength <= lowEmissiveStrength)
            {
                blinkHigh = !blinkHigh;
            }
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
                //play the button click sound
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
    void Delay()
    {
        AkSoundEngine.PostEvent(soundName, gameObject);
    }
}
