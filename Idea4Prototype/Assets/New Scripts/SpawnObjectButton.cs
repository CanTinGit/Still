using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectButton : MonoBehaviour {

    Transform button;               //Get the transform of the button
    public float setWeight;         //Setting weight to check if the button is pressed
    Vector3 originalPosition;       //Save the original data of the button in order to change it back when realsing
    public bool isSpecificObject;   //When it's set, only the specific object can trigger the button or trapss
    public float noise;             //Noise value
    public string noise_detection;  //the name of the noise
    public string SpecificObjectTag; //Set the the specific object
    GameObject spawnerManager;      // Reference to the spawner manager
    public bool isForMetalSphere;
    public bool canDispense;
    public bool audioPlayed = false;

    //controls the blinking lights
    public bool blinkingLights; //controls whether the lights will blink for the button or not
    public GameObject blinkButton; //the button gameobject
    public float lowEmissiveStrength, highEmissiveStrength; // the values ranges it will go between for emissive strength
    bool blinkHigh = true; //a boolean to indicate if it will go to the upper limit or the lower limit ranges
    float blinkEmissiveStrength = 0; //the value the emissive strength will be set to
    public float blinkRateIncrease; //the rate it will change in emissive strength
    // Use this for initialization, set the button and original position of button
    void Start()
    {
        button = gameObject.transform;
        originalPosition = button.gameObject.transform.position;
        spawnerManager = GameObject.Find("SpawnerManager");
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
                // Button go down
                button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
                //play the button click sound
                AkSoundEngine.PostEvent("button_click", gameObject);
                // Spawn the object
                // Not sure what this code is supposed to do, so commented it out for just now
                //if (isForMetalSphere)
                //{
                //    Debug.Log("Metal");
                //    spawnerManager.GetComponent<Spawner>().SpawnMetalSphere();
                //}
                //else
                //{
                //    Debug.Log("Origianl");
                spawnerManager.GetComponent<Spawner>().Spawn();
                //}

            }
            return;
        }
        if (other.GetComponent<Rigidbody>() != null)
        {
            // Check if the mass of object is more than setting weight, if it is, it can make trap run.
            if (other.GetComponent<Rigidbody>().mass >= setWeight && other.gameObject.tag != "Hand")
            {
                // Button go down
                button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
                AkSoundEngine.PostEvent("button_click", gameObject);
                if (GameObject.Find("SpawnerManager").GetComponent<Spawner>().canSpawn == true && audioPlayed ==false)
                {
                    audioPlayed = true;
                        //play the button click sound                      
                        if (GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex == 1)
                        {
                            AkSoundEngine.SetSwitch("Buzz", "Correct", gameObject);
                        }
                        else
                        {
                            AkSoundEngine.SetSwitch("Buzz", "Incorrect", gameObject);
                        }
                        PlayBuzzAudio();
                        //Invoke("SpawnWeight", 0.75f);
                    // Spawn the object   
                }
            }
        }
    }
    void SpawnWeight()
    {
        spawnerManager.GetComponent<Spawner>().Spawn();
    }
    public void PlayBuzzAudio()
    {
        AkSoundEngine.PostEvent("button_buzz", gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);     
    }
        //When the button is released change the button to the original position
        void OnTriggerExit(Collider other)
    {
        button.position = originalPosition;
    }
    //When the button is stayed on then lower the button position
    void OnTriggerStay(Collider other)
    {
        button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
    }
    //setter for canDispense
    public void SetCanDispense(bool canDispense_)
    {
        canDispense = canDispense_;
    }
    //getter for canDispense
    public bool GetDispense()
    {
        return canDispense;
    }

    void MyCallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)
    {
        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            AkEventCallbackInfo info = (AkEventCallbackInfo)in_info; //Then do stuff.
            spawnerManager.GetComponent<Spawner>().Spawn();
        }

    }
}
