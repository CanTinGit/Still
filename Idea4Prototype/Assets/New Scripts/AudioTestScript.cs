using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//template script for testing audio ( for now used in the audio test level)
public class AudioTestScript : MonoBehaviour
{
    private float noiseMade; //the noise that is made
    Rigidbody rigidBody;
    float velocity;
    bool delayBeginAudio = false;
    void Awake()
    {
        //set the rigidBody variable to the componenet
        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<AudioClass>().SetAudioForMaterial("MetalObject");
        Invoke("AudioStart", 1.0f);
        InvokeRepeating("FindTill", 0.0f, 0.01666f);
    }
    public void SetVelocity(float velocity_)
    {
        //Debug.Log(velocity_);
        if(velocity_>=1.0f)
        {
            velocity = velocity_;
        }

    }
    void AudioStart()
    {
        delayBeginAudio = true;
    }
    void FindTill()
    {
        if  (GameObject.FindGameObjectWithTag("Player")!=null)
         {
            MenuScript.Instance.GetAudioClass().SetAudioForMaterial("MetalObject");
            CancelInvoke("FindTill");
        }
    }
    //OLD CODE MAY NOT BE NEEDED FOR NOW TILL WWISE IS BACK
    void LoopWwiseNoise()
    {
        rigidBody = GetComponent<Rigidbody>();
       // int type = 1;
       //float returnNoiseValue;
        //AkSoundEngine.GetRTPCValue("noise_detection", gameObject, 0, out returnNoiseValue, ref type);
        //noiseMade = returnNoiseValue;
    }

    void OnCollisionEnter(Collision col)
    {
        //getting material name e.g. the property of the object
        ////string materialName = this.GetComponent<SphereCollider>().material.name;
        string materialName = "wood_object";
        //gets rid of any extra words added on by unity -.- idk why it adds them
        //materialName = materialName.Remove(materialName.IndexOf(" ("));
        //when the object hits the ground ( test for ground now will include more later)
        if (col.transform.tag == "Ground")
        {
            //gets the force of the hit
            //
            // NEED TO RECALCULATE HOW MUCH FORCE
            ///
            if(delayBeginAudio == true)
            {
                float force = rigidBody.mass * velocity;
                //float force = rigidBody.mass * rigidBody.velocity.magnitude;
                //float force = rigidBody.mass * Physics.gravity.magnitude *  //rigidBody.mass * rigidBody.velocity.magnitude;
                //Debug.Log("audio test force is " + force);
                //plays the sound based on the material and the force and the psz group
                MenuScript.Instance.GetAudioClass().PlayAudio(materialName, force, "Impact_Force");
                //the sound being played ( i think??? )
                AkSoundEngine.PostEvent("object_impact", gameObject);
                if (noiseMade > -20)
                {
                    if (GameObject.FindGameObjectWithTag("CameraObject") != null)
                    {
                        //use this if you want to make the camera to move to this object ( replace "this.transform.position" with the object you want the camera to look at)
                        if (GameObject.FindGameObjectWithTag("AlertSpotlight") == null)
                        {
                            Instantiate(Resources.Load("Prefabs/NewCameraAI"));
                        }
                    }
                    //GameObject.Find("Camera").GetComponent<CameraAI>().DetectedNoise(this.transform.position);
                }
            }
        }
    }
}
    //public float noise; //so you can see it in inspector
    //Rigidbody rigidBody;
    //Vector3 startPos;
    //public float forceToApplyToBall; //value for the force  being applied you can set this in the inspector
    //void Awake()
    //{
    //    startPos = this.transform.position;
    //    forceToApplyToBall = 10.0f;
    //    Debug.Log(startPos);
    //}
    //void Update()
    //{
    //    rigidBody = GetComponent<Rigidbody>();
    //    int type = 1;
    //    float value;
    //    AkSoundEngine.GetRTPCValue("noise_detection", gameObject, 0, out value, ref type);
    //    noise = value;
    //    Controls();
    //}

    //void Controls()
    //{
    //    //reset the ball back to original position
    //    if (Input.GetKeyDown(KeyCode.KeypadEnter))
    //    {
    //        this.transform.position = startPos;
    //    }
    //    //add force onto the ball to make bounce
    //    if (Input.GetKeyDown(KeyCode.KeypadPlus))
    //    {
    //        rigidBody.AddForce(Vector3.up * forceToApplyToBall, ForceMode.Impulse);
    //    }
    //}
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.transform.tag == "Ground")
    //    {
    //        float force = rigidBody.mass * rigidBody.velocity.magnitude;
    //        //Debug.Log("force is " + force);
    //        if (force >= 10)
    //        {
    //            AkSoundEngine.SetState("Impact_Force", "Heavy");
    //        }
    //        else if (force >= 5 && force <= 10)
    //        {
    //            AkSoundEngine.SetState("Impact_Force", "Medium");
    //        }
    //        else if (force >= 2 && force <= 5)
    //        {
    //            AkSoundEngine.SetState("Impact_Force", "Light");
    //        }
    //        else if (force <= 2)
    //        {
    //            AkSoundEngine.SetState("Impact_Force", "Very_Light");
    //        }
    //        //the noise metter debug
    //        //Debug.Log("the noise meter float is " + noise);
    //        Invoke("AudioDelay", 0.2f);
    //        //the sound being played
    //        AkSoundEngine.PostEvent("can_impact", gameObject);
    //        if (noise > -20)
    //        {
    //            //commented out test to only play sound when the force is loud enough ( works fine)
    //            AkSoundEngine.PostEvent("button_click", gameObject);

    //            //use this if you want to make the camera to move to this object ( replace "this.transform.position" with the object you want the camera to look at)
    //            GameObject.Find("Camera").GetComponent<CameraAI>().DetectedNoise(this.transform.position);
    //            Debug.Log("th bullet shot " + this.gameObject.name);
    //        }
    //    }
    //}

    //void AudioDelay()
    //{
    //    //Debug.Log("the noise meter float is " + noise);
    //}
//}
