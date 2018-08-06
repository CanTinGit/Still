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
    // Use this for initialization, set the button and original position of button
    void Start()
    {
        button = gameObject.transform;
        originalPosition = button.gameObject.transform.position;
        spawnerManager = GameObject.Find("SpawnerManager");
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
                // Spawn the object
                spawnerManager.GetComponent<Spawner>().Spawn();
            }
        }
    }

    //When the button is realsed
    void OnTriggerExit(Collider other)
    {
        button.position = originalPosition;
    }

    //When the button is stayed on
    void OnTriggerStay(Collider other)
    {
        button.position = new Vector3(originalPosition.x, originalPosition.y - 0.2f, originalPosition.z);
    }

    public void SetCanDispense(bool canDispense_)
    {
        canDispense = canDispense_;
    }

    public bool GetDispense()
    {
        return canDispense;
    }
}
