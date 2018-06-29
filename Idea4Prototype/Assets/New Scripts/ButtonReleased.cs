using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReleased : MonoBehaviour
{

    Transform button;
    public float setWeight;
    Vector3 originalPosition;
    public Animator CraneheadAnimator;
    public bool isRunOnce;
    public bool isSpecificObject;
    public float noise;
    public string noise_detection;
    public GameObject SpecificObject;
    public string animationBoolean;
    public string soundName;
    public float delaySound;
    // Use this for initialization
    void Start()
    {
        button = gameObject.transform.parent;
        originalPosition = button.gameObject.transform.position;
    }

    //this is it Mo
    //right here
    void Update()
    {
        int type = 1;
        //float value;
        //AkSoundEngine.GetRTPCValue("noise_detection", gameObject, 0, out value, ref type);
        //noise = value;
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (isSpecificObject)
        {
            if (other.gameObject == SpecificObject)
            {
                //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
                if (isRunOnce == true)
                {
                    animator.SetTrigger("isButtonReleased");
                }
                else
                {
                    animator.SetBool("isButtonReleased", false);
                }
            }
            return;
        }
        // Check if the mass of object is more than setting weight, if it is, it can make trap run.
        if (other.GetComponent<Rigidbody>().mass >= setWeight)
        {
            // Button go down
            button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
            AkSoundEngine.PostEvent("button_click", gameObject);
            Debug.Log(noise);

            //Check if the trap just run once, if it is, use settrigger to run it, if not, use setbool to run it so that it can run multiply times
            if (isRunOnce == true)
            {
                animator.SetTrigger("isButtonReleased");
            }
            else
            {
                animator.SetBool("isButtonReleased", false);
            }

        }
    }
    */

    void OnTriggerExit(Collider other)
    {
        button.position = originalPosition;
        if (isRunOnce == false)
        {
            CraneheadAnimator.SetBool(animationBoolean, true);
            Invoke("Delay", delaySound);
            
        }
    }
    void Delay()
    {
        AkSoundEngine.PostEvent(soundName, gameObject);
    }

}