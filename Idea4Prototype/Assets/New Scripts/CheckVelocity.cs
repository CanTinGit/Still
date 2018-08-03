using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVelocity : MonoBehaviour {

    float lastvelocity;
    
    void Start()
    {
        InvokeRepeating("UpdateVelocity", 0.0f, 0.01f);
        
    }
	// Update is called once per frame
	void UpdateVelocity ()
    {

            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1.0f)
            {
                lastvelocity = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
                if(this.gameObject.GetComponent<AudioTestScript>())
                {
                    this.gameObject.GetComponent<AudioTestScript>().SetVelocity(lastvelocity);
                }
                
            //Debug.Log("the check " + gameObject.GetComponent<Rigidbody>().velocity);
            }
        
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            //maybe delete the check velocity script since we found the velocity
            Destroy(this.GetComponent<CheckVelocity>());
        }
    }
}
