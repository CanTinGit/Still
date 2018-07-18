using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    public float force;
    public Transform head;
    public GameObject hammer;
	

    void AddForce()
    {
        hammer.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * force,head.position);
        Invoke("DestoryHingeJoint", 0.9f);
    }

    void DestoryHingeJoint()
    {
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(hammer.GetComponent<HingeJoint>());
    }
}
