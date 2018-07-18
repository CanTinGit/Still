using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBubble : MonoBehaviour {

    Rigidbody[] rbs;
    Vector3 peek, bottom;
    float startTime, journeyTime;
    Color lerpedColor,transparentColor,originalColor;
    bool isImmune;
    // Use this for initialization
    void Start ()
    {
        isImmune = false;
        lerpedColor = gameObject.GetComponent<Renderer>().material.color;
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        transparentColor = new Color(0, 0, 0, 0);
        //Disable the gravity and add a force to heavy the player
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up*30.0f, ForceMode.Acceleration);
        gameObject.GetComponent<MovementUpdated>().enabled = false;
        AkSoundEngine.PostEvent("bubble_rise", gameObject);

        //Cancel gravity of player's hand
        rbs = gameObject.transform.GetChild(1).gameObject.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].useGravity = false;
        }
        // After 5 seconds, let gravity work
        Invoke("CancelBubble", 5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isImmune == true)
        {
            lerpedColor = Color.Lerp(originalColor, transparentColor, Mathf.PingPong(Time.time, 1));
            gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        }
    }

    void CancelBubble()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].useGravity = true;
        }
        gameObject.GetComponent<MovementUpdated>().enabled = true;
        isImmune = true;
        Invoke("ChangePlayerBack", 3.0f);
    }

    void ChangePlayerBack()
    {
        gameObject.GetComponent<MovementUpdated>().isInBubble = false;
        gameObject.GetComponent<Renderer>().material.color = originalColor;
        Destroy(this);
    }
}
