using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour {

    Rigidbody rb;
    public Transform position;
    bool Push = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Push = true;
            Debug.Log("P");
            rb.AddForce(this.transform.up * 200f, ForceMode.VelocityChange);
        }
	}

    void OnCollisionStay(Collision col)
    {
        if(col.transform.tag=="Player")
        {
            if(!Push)
            {
                col.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20f, ForceMode.VelocityChange);
                Push = true;
            }          
        }
    }
}
